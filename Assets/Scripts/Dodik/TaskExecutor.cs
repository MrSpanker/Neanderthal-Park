using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskExecutor : MonoBehaviour
{
    [SerializeField] private TaskContainer _taskContainer;
    [SerializeField] private DodikComponent _dodikComponent;

    private TaskData _currentTask;
    private int _currentSubTaskIndex = 0;

    //private void OnEnable()
    //{
    //    _dodikComponent.SearchSuccessfullyCompleted += StartNextSubTask;
    //}

    //private void OnDisable()
    //{
    //    _dodikComponent.SearchSuccessfullyCompleted -= StartNextSubTask;
    //}

    private void Start()
    {
        StartNewTask();
    }

    private void StartNewTask()
    {
        _currentTask = _taskContainer.GetNewTask();

        if (_currentTask == null || _currentTask.SubTasks == null || _currentTask.SubTasks.Count == 0)
        {
            Debug.LogError("Невозможно начать новую задачу: задача или подзадачи не заданы или отсутствуют.");
            return;
        }

        _currentSubTaskIndex = 0;
        StartNextSubTask();
    }

    private void StartNextSubTask()
    {
        if (_currentSubTaskIndex >= _currentTask.SubTasks.Count)
        {
            Debug.LogWarning("Завершены все подзадачи для текущей задачи.");
            StartNewTask();
            return;
        }

        SubTaskData nextSubTask = _currentTask.SubTasks[_currentSubTaskIndex];
        _dodikComponent.InitiateSearch(nextSubTask.ObjectType);

        _currentSubTaskIndex++;
    }
}
