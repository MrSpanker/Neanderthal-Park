using UnityEngine;

[System.Serializable]
public abstract class DesireStage
{
    public abstract void ExecuteStage(GameObject character, LevelComponent levelComponent);
}