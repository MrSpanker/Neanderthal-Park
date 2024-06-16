using UnityEngine;

public class DodikComponent : BaseCharacter
{
    [SerializeField] private DodikStateMachine _dodikStateMachine;
    [SerializeField] private DodikPerceptionZones _dodikPerceptionZones;

    public void InitiateSearch(ObjectType objectType)
    {
        _dodikPerceptionZones.SetSearchObjectTag(objectType);
    }
}