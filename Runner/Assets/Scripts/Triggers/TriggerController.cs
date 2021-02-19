﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TriggerController : MonoBehaviour
{
    [SerializeField] private LayerMask triggerMask;
    [SerializeField] private GameObject jumpTrigger;
    [SerializeField] private GameObject dashTrigger;
    [SerializeField] private GameObject idleTrigger;
    [SerializeField] private GameObject faceLeftTrigger;
    [SerializeField] private GameObject faceRightTrigger;
    private GameObject selected = null;

    [SerializeField] private Text limitText;
    [SerializeField] private int limit = 1;
    private int total = 0;

    private void Start()
    {
        limitText.text = $"0 / {limit}";                
    }

    private void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (selected)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    var selectedPrice = selected.GetComponent<Trigger>().price;
                    if (total + selectedPrice > limit)
                    {
                        DeleteShadow();
                        return;
                    }

                    var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f, triggerMask);
                    if (!hit.collider)
                    {
                        selected.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                        total += selectedPrice;
                        limitText.text = $"{total} / {limit}";

                        selected = Instantiate(selected);
                        selected.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
                    }
                    else
                    {
                        DeleteShadow();
                    }
                }
                else if (Input.GetMouseButtonUp(1))
                {
                    DeleteShadow();
                }
                else
                {
                    var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePosition.z = 0;
                    selected.transform.position = mousePosition;
                    selected.GetComponent<SpriteRenderer>().sortingOrder = 1;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                {
                    DeleteTrigger();
                }
            }
        }
    }

    private void DeleteShadow()
    {
        Destroy(selected);
        selected = null;
    }

    private void DeleteTrigger()
    {
        var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider && hit.collider.CompareTag("Trigger"))
        {
            var trigger = hit.collider.gameObject;
            total -= trigger.GetComponent<Trigger>().price;
            limitText.text = $"{total} / {limit}";
            Destroy(trigger);
        }
    }

    public void SelectJumpTrigger()
    {
        DeleteShadow();
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        selected = Instantiate(jumpTrigger, mousePosition, Quaternion.identity);
        selected.GetComponent<EditModeGridSnap>().AllowIngame = true;
        selected.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    public void SelectDashTrigger()
    {
        DeleteShadow();
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        selected = Instantiate(dashTrigger, mousePosition, Quaternion.identity);
        selected.GetComponent<EditModeGridSnap>().AllowIngame = true;
        selected.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    public void SelectIdleTrigger()
    {
        DeleteShadow();
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        selected = Instantiate(idleTrigger, mousePosition, Quaternion.identity);
        selected.GetComponent<EditModeGridSnap>().AllowIngame = true;
        selected.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    public void SelectFaceLeftTrigger()
    {
        DeleteShadow();
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        selected = Instantiate(faceLeftTrigger, mousePosition, Quaternion.identity);
        selected.GetComponent<EditModeGridSnap>().AllowIngame = true;
        selected.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    public void SelectFaceRightTrigger()
    {
        DeleteShadow();
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        selected = Instantiate(faceRightTrigger, mousePosition, Quaternion.identity);
        selected.GetComponent<EditModeGridSnap>().AllowIngame = true;
        selected.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }
}
