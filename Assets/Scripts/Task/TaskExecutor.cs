using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskExecutor : MonoBehaviour
{
    [SerializeField] private TaskContainer _taskContainer;
    [SerializeField] private DodikComponent _dodikComponent;
    [SerializeField] private InteractionWithObjectState _interactionWithObjectState;
    [SerializeField] private MoodDodik _moodDodik;
    [SerializeField] private List<GameObject> _taskViewList;
    [SerializeField] private float _timeBetweenTasks = 5f;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private TaskData _currentTask;
    private int _currentSubTaskIndex = 0;
    private Coroutine _taskStartDelay;

    private void OnEnable()
    {
        if (_interactionWithObjectState != null)
            _interactionWithObjectState.InteractionCompleted += StartNextSubTask;
    }

    private void OnDisable()
    {
        if (_interactionWithObjectState != null)
            _interactionWithObjectState.InteractionCompleted -= StartNextSubTask;
    }

    private void Start()
    {
        for (int i = 0; i < _taskViewList.Count; i++)
        {
            _taskViewList[i].SetActive(false);
        }
        _taskStartDelay = StartCoroutine(StartNewTask());
    }

    private void DisplayNewTaskView()
    {
        for (int i = 0; i < _taskViewList.Count; i++)
        {
            _taskViewList[i].SetActive(false);
        }

        for (int i = 0; i < _taskViewList.Count && i < _currentTask.SubTasks.Count; i++)
        {
            _taskViewList[i].SetActive(true);
            _taskViewList[i].GetComponent<Image>().sprite = _currentTask.SubTasks[i].Image;
        }
    }

    private void UpdateTaskView()
    {
        if (_currentSubTaskIndex < _taskViewList.Count)
        {
            _taskViewList[_currentSubTaskIndex - 1].SetActive(false);
        }
        Debug.Log("Таск " + _currentSubTaskIndex + " выполнен");
    }

    private IEnumerator StartNewTask()
    {
        if (_currentSubTaskIndex != 0)
            _audioSource.PlayOneShot(_audioClip);

        for (int i = 0; i < _taskViewList.Count; i++)
        {
            _taskViewList[i].SetActive(false);
        }

        yield return new WaitForSeconds(_timeBetweenTasks);

        _currentTask = _taskContainer.GetNewTask();

        if (_currentTask == null || _currentTask.SubTasks == null || _currentTask.SubTasks.Count == 0)
        {
            Debug.LogError("Невозможно начать новую задачу: задача или подзадачи не заданы или отсутствуют.");
            yield break;
        }

        _moodDodik.PlusMood();
        _currentSubTaskIndex = 0;
        DisplayNewTaskView();
        StartNextSubTask();
    }

    private void StartNextSubTask()
    {
        if (_currentSubTaskIndex >= _currentTask.SubTasks.Count)
        {
            Debug.LogWarning("Завершены все подзадачи для текущей задачи.");

            if (_taskStartDelay != null)
                StopCoroutine(_taskStartDelay);
            _taskStartDelay = StartCoroutine(StartNewTask());

            return;
        }

        SubTaskData nextSubTask = _currentTask.SubTasks[_currentSubTaskIndex];

        if (_currentSubTaskIndex != 0)
        {
            UpdateTaskView();
        }

        _dodikComponent.InitiateSearch(nextSubTask.ObjectType);
        _currentSubTaskIndex++;
    }
}