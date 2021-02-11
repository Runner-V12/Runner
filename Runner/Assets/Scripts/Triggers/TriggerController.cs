using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TriggerController : MonoBehaviour
{
        [SerializeField] private GameObject trigger;

        private void Update()
        {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                        if (Input.GetMouseButtonDown(0))
                        {
                                CreateTrigger(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                        } else if (Input.GetMouseButtonDown(1))
                        {
                                DeleteTrigger(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                        }
                }
        }

        private void CreateTrigger(Vector3 mousePosition)
        {
                mousePosition.z = 0;
                Instantiate(trigger, mousePosition, Quaternion.identity);
        }

        private void DeleteTrigger(Vector3 mousePosition)
        {

        }
}
