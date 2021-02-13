using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDash : Trigger
{
    protected override void Action(GameObject collided)
    {
        collided.GetComponent<PlayerController>().Dash();
    }
}
