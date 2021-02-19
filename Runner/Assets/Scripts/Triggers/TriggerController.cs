using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TriggerController : MonoBehaviour
{
    [SerializeField] private LayerMask triggerMask;
    [SerializeField] private GameObject jumpTrigger;
    [SerializeField] private GameObject dashTrigger;
    [SerializeField] private GameObject idleTrigger;
    [SerializeField] private GameObject faceLeftTrigger;
    [SerializeField] private GameObject faceRightTrigger;
    private GameObject selected = null;


    private void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (selected)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var hit = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f, triggerMask);
                    if (hit.Length <= 1)
                    {
                        selected.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        selected = null;
                    }
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
                if (Input.GetMouseButtonDown(0))
                {
                    DeleteTrigger();
                }
            }
        }
    }

    private void DeleteTrigger()
    {
        var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider && hit.collider.CompareTag("Trigger"))
        {
            Destroy(hit.collider.gameObject);
        }
    }

    public void SelectJumpTrigger()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        selected = Instantiate(jumpTrigger, mousePosition, Quaternion.identity);
        selected.GetComponent<EditModeGridSnap>().AllowIngame = true;
        selected.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    public void SelectDashTrigger()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        selected = Instantiate(dashTrigger, mousePosition, Quaternion.identity);
        selected.GetComponent<EditModeGridSnap>().AllowIngame = true;
        selected.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    public void SelectIdleTrigger()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        selected = Instantiate(idleTrigger, mousePosition, Quaternion.identity);
        selected.GetComponent<EditModeGridSnap>().AllowIngame = true;
        selected.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    public void SelectFaceLeftTrigger()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        selected = Instantiate(faceLeftTrigger, mousePosition, Quaternion.identity);
        selected.GetComponent<EditModeGridSnap>().AllowIngame = true;
        selected.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    public void SelectFaceRightTrigger()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        selected = Instantiate(faceRightTrigger, mousePosition, Quaternion.identity);
        selected.GetComponent<EditModeGridSnap>().AllowIngame = true;
        selected.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }
}
