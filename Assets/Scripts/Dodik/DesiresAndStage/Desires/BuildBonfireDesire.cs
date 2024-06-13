using UnityEngine;

[System.Serializable]
public class BuildBonfireDesire : Desire
{
    public BuildBonfireDesire(LevelComponent levelComponent)
    {
        // ������ ����� ���������� ��� ������� ��������� �����
        AddStage(new MoveToPositionStage(levelComponent.BranchPositions[0])); // ������� � �����
        AddStage(new InteractWithObjectStage("Branch")); // ����������������� � ������
        AddStage(new MoveToPositionStage(levelComponent.BonfirePosition)); // ������� � ����� ��� ������
        AddStage(new CreateBonfireStage()); // ������� ������
    }
}
