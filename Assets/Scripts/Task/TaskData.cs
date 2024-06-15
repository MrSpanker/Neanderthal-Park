using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTaskData", menuName = "Task/TaskData")]
public class TaskData : ScriptableObject
{
    public List<SubTaskData> SubTasks;
}
