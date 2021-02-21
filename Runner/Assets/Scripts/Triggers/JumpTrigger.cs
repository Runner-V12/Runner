using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : Trigger
{
    [SerializeField] private GameObject jumpParticles;
    protected override void Action(GameObject collided)
    {
        collided.GetComponent<PlayerController>().Jump();
        Destroy(Instantiate(jumpParticles, collided.transform.position, Quaternion.identity), 2);
    }
}
