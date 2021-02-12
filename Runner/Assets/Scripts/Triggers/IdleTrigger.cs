using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTrigger : Trigger
{
    protected override void Action(GameObject collided)
    {
        collided.GetComponent<PlayerController>().idle();
    }
}
