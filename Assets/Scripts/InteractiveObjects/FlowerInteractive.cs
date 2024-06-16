using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerInteractive : InteractiveObject
{
    public override void Interact()
    {
        GameObject.Destroy(this.gameObject);
    }
}
