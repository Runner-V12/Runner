using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerList : MonoBehaviour
{
        [SerializeField] private List<GameObject> triggers;

        private void Awake()
        {
                foreach (var trigger in triggers)
                {
                        var button = Instantiate(trigger);
                        button.transform.SetParent(transform);
                        button.transform.localScale = Vector3.one;
                }
        }
}
