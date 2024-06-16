using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickInteractive : InteractiveObject
{
    public override void Interact()
    {
        GameObject.Destroy(this.gameObject);
    }
}
