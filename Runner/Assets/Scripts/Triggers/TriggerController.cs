using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TriggerController : MonoBehaviour
{
    [SerializeField] private LayerMask triggerMask;
    [SerializeField] private GraphicRaycaster graphicRaycaster;

    [SerializeField] private GameObject jumpTrigger;
    [SerializeField] private GameObject dashTrigger;
    [SerializeField] private GameObject idleTrigger;
    [SerializeField] private GameObject faceLeftTrigger;
    [SerializeField] private GameObject faceRightTrigger;
    private GameObject selected = null;
    private int selectedLayer = 0;

    [SerializeField] private Text limitText;
    private Color normalLimitColor;
    [SerializeField] private Color limitReachedColor = new Color(135, 43 , 0);
    [SerializeField] private int limit = 1;
    private int total = 0;

    [SerializeField] private float shakeDuration = 0.25f;
    [SerializeField] private float shakeIntensity = 0.25f;

    private void Start()
    {
        limitText.text = $"0 / {limit}";
        normalLimitColor = limitText.color;
    }

    private void Update()
    {
        if (selected)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            selected.transform.position = mousePosition;

            if (Input.GetMouseButtonUp(0))
            {
                var selectedPrice = selected.GetComponent<Trigger>().price;
                if (total + selectedPrice > limit)
                {
                    DeleteShadow();
                    return;
                }

                var pointerData = new PointerEventData(EventSystem.current)
                {
                    position = Input.mousePosition
                };
                var results = new List<RaycastResult>();
                graphicRaycaster.Raycast(pointerData, results);
                if (!EventSystem.current.IsPointerOverGameObject() || (results.Count == 0 || (triggerMask == (triggerMask | (1 << results[0].gameObject.layer)))))
                {
                    var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f, triggerMask);
                    if (!hit.collider)
                    {
                        selected.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        selected.layer = selectedLayer;

                        total += selectedPrice;
                        limitText.text = $"{total} / {limit}";
                        if (limit == total)
                        {
                            limitText.color = limitReachedColor;
                            CameraShake.Shake(shakeDuration, shakeIntensity);
                        }

                        CreateShadow(selected);
                    }
                    else
                    {
                        DeleteShadow();
                    }
                }
            }
            else if (Input.GetMouseButtonUp(1))
            {
                DeleteShadow();
            }
        }
        else if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            DeleteTrigger();
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
            limitText.color = normalLimitColor;
            Destroy(trigger);
        }
    }

    private void CreateShadow(in GameObject trigger)
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        selected = Instantiate(trigger, mousePosition, Quaternion.identity);
        selectedLayer = selected.layer;
        selected.layer = 0;
        selected.GetComponent<EditModeGridSnap>().AllowIngame = true;
        selected.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        selected.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    public void SelectJumpTrigger()
    {
        DeleteShadow();
        CreateShadow(jumpTrigger);
    }

    public void SelectDashTrigger()
    {
        DeleteShadow();
        CreateShadow(dashTrigger);
    }

    public void SelectIdleTrigger()
    {
        DeleteShadow();
        CreateShadow(idleTrigger);
    }

    public void SelectFaceLeftTrigger()
    {
        DeleteShadow();
        CreateShadow(faceLeftTrigger);
    }

    public void SelectFaceRightTrigger()
    {
        DeleteShadow();
        CreateShadow(faceRightTrigger);
    }
}
