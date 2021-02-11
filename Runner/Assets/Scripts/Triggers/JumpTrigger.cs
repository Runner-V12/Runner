using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : Trigger
{
        [SerializeField][Tooltip("Scaled 100 times for simplicity")] private float jumpForce;

        private void Awake()
        {
                jumpForce *= 100;
        }

        protected override void Action(GameObject collided)
        {
                var body = collided.GetComponent<Rigidbody2D>();
                body.AddForce(new Vector2(0f, jumpForce));
        }
}
