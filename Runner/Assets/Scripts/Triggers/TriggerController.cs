using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TriggerController : MonoBehaviour
{
        [SerializeField] private GameObject jumpTrigger;
        [SerializeField] private GameObject faceLeftTrigger;
        [SerializeField] private GameObject faceRightTrigger;
        private GameObject selected = null;

        private void Update()
        {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                        if (Input.GetMouseButtonDown(0))
                        {
                                CreateTrigger();
                        } else if (Input.GetMouseButtonDown(1))
                        {
                                DeleteTrigger();
                        }
                }
        }

        private void CreateTrigger()
        {
                if (selected)
                {
                        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        mousePosition.z = 0;
                        Instantiate(selected, mousePosition, Quaternion.identity);
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
                selected = jumpTrigger;
        }

        public void SelectFaceLeftTrigger()
        {
                selected = faceLeftTrigger;
        }

        public void SelectFaceRightTrigger()
        {
                selected = faceRightTrigger;
        }
}
