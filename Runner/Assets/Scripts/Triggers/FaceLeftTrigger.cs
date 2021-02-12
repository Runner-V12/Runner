using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceLeftTrigger : Trigger
{
    protected override void Action(GameObject collided)
    {
        collided.GetComponent<PlayerController>().goLeft();
    }
}
