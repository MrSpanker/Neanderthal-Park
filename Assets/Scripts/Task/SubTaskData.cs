using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSubTaskData", menuName = "Task/SubTaskData")]
public class SubTaskData : ScriptableObject
{
    public Sprite Image;
    public ObjectType ObjectType;
}
