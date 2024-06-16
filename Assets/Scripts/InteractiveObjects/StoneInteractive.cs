using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneInteractive : InteractiveObject
{
    public override void Interact()
    {
        GameObject.Destroy(this.gameObject);
    }
}
