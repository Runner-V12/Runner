using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
        [SerializeField] protected GameObject player = null;

        private void Awake()
        {
                if (player == null)
                {
                        player = GameObject.FindGameObjectWithTag("Player");
                        if (player == null)
                        {
                                throw new ArgumentNullException("The game needs a player");
                        }
                }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
                Action(collision.gameObject);
        }

        protected abstract void Action(GameObject collided);
}
