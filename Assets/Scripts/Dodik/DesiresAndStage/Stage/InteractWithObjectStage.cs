using UnityEngine;

[System.Serializable]
public class InteractWithObjectStage : DesireStage
{
    private string objectTag;

    public InteractWithObjectStage(string tag)
    {
        objectTag = tag;
    }

    public override void ExecuteStage(GameObject character, LevelComponent levelComponent)
    {
        // Логика взаимодействия с объектом
        // Здесь вставить логику взаимодействия
    }
}