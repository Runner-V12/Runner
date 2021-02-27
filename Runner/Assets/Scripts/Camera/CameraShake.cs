using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    private Vector3 originalPosition;

    private void Start()
    {
        instance = this;
    }

    public static void Shake(float duration, float amount)
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.shakeImplementation(duration, amount));
    }

    public IEnumerator shakeImplementation(float duration, float amount)
    {
        float endTime = Time.time + duration;
        originalPosition = transform.localPosition;

        while (Time.time < endTime)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * amount;

            duration -= Time.deltaTime;

            yield return duration;
        }

        transform.localPosition = originalPosition;
    }
}
