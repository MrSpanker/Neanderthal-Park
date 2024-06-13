using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Desire
{
    public Queue<Goal> _goalQueue = new();

    public Goal GetNewGoal()
    {
        if (_goalQueue.Count > 0)
        {
            return _goalQueue.Dequeue();
        }
        else
        {
            Debug.LogError("��� ���� ��� ������� " + GetType().Name + " ���������");
            return null;
        }
    }
}
