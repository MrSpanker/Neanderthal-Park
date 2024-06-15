using UnityEngine;
using UnityEngine.Events;

public class InteractionWithObjectState : State
{
    public event UnityAction<bool> InteractionCompleted;
    private bool interactionCompleted = false;

    private void OnEnable()
    {
        interactionCompleted = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!interactionCompleted)
        {
            CheckCollision(other);
        }
    }

    private void CheckCollision(Collider other)
    {
        if (!other.gameObject.CompareTag("Ground"))
        {
            interactionCompleted = true;
            InteractionCompleted?.Invoke(true);
        }
        else
        {
            interactionCompleted = true;
            InteractionCompleted?.Invoke(false);
        }
    }
}
