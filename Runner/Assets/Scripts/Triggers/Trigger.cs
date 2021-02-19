using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    [SerializeField] public int price = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Action(collision.gameObject);
    }
    protected abstract void Action(GameObject collided);
}
