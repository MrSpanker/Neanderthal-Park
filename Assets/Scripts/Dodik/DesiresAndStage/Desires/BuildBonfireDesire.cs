using UnityEngine;

[System.Serializable]
public class BuildBonfireDesire : Desire
{
    public BuildBonfireDesire(LevelComponent levelComponent)
    {
        // Создаём этапы выполнения для желания построить костёр
        AddStage(new MoveToPositionStage(levelComponent.BranchPositions[0])); // Подойти к ветке
        AddStage(new InteractWithObjectStage("Branch")); // Взаимодействовать с веткой
        AddStage(new MoveToPositionStage(levelComponent.BonfirePosition)); // Подойти к месту для костра
        AddStage(new CreateBonfireStage()); // Создать костер
    }
}
