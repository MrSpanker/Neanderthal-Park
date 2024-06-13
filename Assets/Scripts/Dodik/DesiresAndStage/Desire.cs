using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Desire
{
    [SerializeField]
    private List<DesireStage> stages = new List<DesireStage>();

    public List<DesireStage> Stages { get { return stages; } }

    public void AddStage(DesireStage stage)
    {
        stages.Add(stage);
    }

    public void RemoveStage(DesireStage stage)
    {
        stages.Remove(stage);
    }

    public void Execute(GameObject character, LevelComponent levelComponent)
    {
        foreach (var stage in stages)
        {
            stage.ExecuteStage(character, levelComponent);
        }
    }
}
