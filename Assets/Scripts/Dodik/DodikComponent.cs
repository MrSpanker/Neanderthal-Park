using System;
using UnityEngine;
using UnityEngine.Events;

public class DodikComponent : BaseCharacter
{
    public event UnityAction SearchSuccessfullyCompleted;
    public bool IsSearching { get; private set; }

    [SerializeField] private DodikStateMachine _dodikStateMachine;
    [SerializeField] private SearchTransition _searchTransition;
    [SerializeField] private LevelComponent _levelComponent;
    [SerializeField] private DodikPerceptionZones _dodikPerceptionZones;
    //[SerializeField] private InteractionWithObjectState _interactionWithObjectState;

    private void OnEnable()
    {
        //_interactionWithObjectState.InteractionCompleted += ProcessResultOfInteraction;
        //_dodikPerceptionZones.ObjectForSearchDetected += OnObjectForSearchDetected;
    }
    
    private void OnDisable()
    {
        //_interactionWithObjectState.InteractionCompleted -= ProcessResultOfInteraction;
        //_dodikPerceptionZones.ObjectForSearchDetected -= OnObjectForSearchDetected;
    }

    //private void ProcessResultOfInteraction(bool successfully)
    //{
    //    if (successfully)
    //    {
    //        SearchSuccessfullyCompleted?.Invoke();
    //    }
    //    else
    //    {
    //        _dodikStateMachine.SetTarget(_levelComponent.GetRandomTileObject());
    //        //_searchTransition.SetNeedTransit(true);
    //    }
    //}

    private void OnObjectForSearchDetected(GameObject gameObject)
    {
        _dodikStateMachine.SetTarget(gameObject);
    }

    public void InitiateSearch(ObjectType objectType)
    {
        _dodikPerceptionZones.SetSearchObjectTag(objectType);
        IsSearching = true;
    }

    public void RepeatSearch()
    {
        IsSearching = true;
    }
}