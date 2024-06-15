using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTransition : Transition
{
    [SerializeField] private DodikPerceptionZones _dodikPerceptionZones;

    private void OnTriggerEnter(Collider other)
    {
        string otherTag = other.gameObject.tag;
        Debug.Log("��� �������: " + otherTag);

        if (other.CompareTag(_dodikPerceptionZones.GetSearchObjectTag().ToString()))
        {
            Debug.Log("����� ��: " + other.gameObject.name);
            NeedTransit = true;
        }
    }
}
