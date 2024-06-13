using UnityEngine;

[System.Serializable]
public class MoveToPositionStage : DesireStage
{
    private Vector3 targetPosition;

    public MoveToPositionStage(Vector3 position)
    {
        targetPosition = position;
    }

    public override void ExecuteStage(GameObject character, LevelComponent levelComponent)
    {
        // Логика передвижения персонажа к targetPosition
        // Здесь вставить логику передвижения
    }
}