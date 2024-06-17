using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    [SerializeField] private Fishing _fishing;
    private void Update()
    {
        if (_fishing.IsFishCaught == false)
            transform.position = Input.mousePosition;
    }
}
