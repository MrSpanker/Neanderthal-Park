using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class InteractionWithObjectState : State
{
    public event UnityAction InteractionCompleted;

    [SerializeField] private DodikPerceptionZones _dodikPerceptionZones;
    [SerializeField] private float _interactionDelay = 0.8f;
    [SerializeField] private float _animationDuration = 0.5f;
    [SerializeField] private Fishing _fishing;

    private readonly string _interactAnimationParameter = "Interact";
    private readonly string _creationAnimationParameter = "Creation";
    private Coroutine _interactionCoroutine;
    private float _currentAnimationDuration;

    protected override void OnEnable()
    {
        Target.TryGetComponent<InteractiveObject>(out InteractiveObject interactiveObject);
        if (interactiveObject == null)
        {
            return;
        }

        if (interactiveObject.GetInteractionType() == InteractionType.PickUp)
        {
            _animationParameterName = _interactAnimationParameter;
            _currentAnimationDuration = _animationDuration;
        }
        else if (interactiveObject.GetInteractionType() == InteractionType.Build)
        {
            _animationParameterName = _creationAnimationParameter;
            _currentAnimationDuration = _animationDuration * 4;
        }
        else if (interactiveObject.GetInteractionType() == InteractionType.Fishing)
        {
            interactiveObject.Interact();
            _fishing.StartFishing();
            _fishing.OnFishingEnded.AddListener(WaitInteractionEnd);
            return;
        }

        base.OnEnable();
        _interactionCoroutine = StartCoroutine(InteractWithDelay(interactiveObject, _currentAnimationDuration));
    }

    private void WaitInteractionEnd()
    {
        InteractionCompleted?.Invoke();
        _fishing.OnFishingEnded.RemoveListener(WaitInteractionEnd);
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        if (_interactionCoroutine != null)
        {
            StopCoroutine(_interactionCoroutine);
            _interactionCoroutine = null;
        }
    }

    private IEnumerator InteractWithDelay(InteractiveObject interactiveObject, float animationDuration)
    {
        yield return new WaitForSeconds(_interactionDelay);
        _dodikPerceptionZones.SetSearchObjectTag(ObjectType.Null);

        if (gameObject.activeInHierarchy && interactiveObject != null)
        {
            interactiveObject.Interact();
            yield return new WaitForSeconds(animationDuration);
            InteractionCompleted?.Invoke();
        }
    }
}
