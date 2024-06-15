using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskContainer : MonoBehaviour
{
    [SerializeField] private List<TaskData> _taskList;

    private Queue<TaskData> _taskQueue;

    private void OnEnable()
    {
        _taskQueue = new Queue<TaskData>(_taskList);
    }   

    public void AddTaskToQueue(TaskData task)
    {
        _taskQueue.Enqueue(task);
        Debug.Log("��������� ������: " + task.name);
    }

    public TaskData GetNewTask()
    {
        if (_taskQueue.Count > 0)
        {
            TaskData task = _taskQueue.Dequeue();
            Debug.Log("������� ������: " + task.name);
            return task;
        }
        else
        {
            Debug.LogWarning("����� �� ��������");
            return null;
        }
    }
}