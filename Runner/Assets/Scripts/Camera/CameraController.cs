using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed = 30.0f;

    [SerializeField] private GameObject Left_button;
    [SerializeField] private GameObject Right_button;

    private GameObject _camera;
    private Vector3 target;

    private float maxX;

    private GameController gameController;

    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        target = _camera.transform.position;
        gameController = GetComponent<GameController>();

        var maxXList = new List<float>();
        var aL = GameObject.FindGameObjectsWithTag("Ground");
        foreach (var item in aL)
        {
            maxXList.Add(item.transform.position.x);
        }
        maxX = Mathf.Max(maxXList.ToArray());
    }

    public void GoRight()
    {
        if (target.x < maxX)
            target.x += 10;
    }
    public void GoLeft()
    {
        if (target.x > 0)
            target.x -= 10;
    }

    private void Update()
    {
        if (gameController.editMode)
        {
            float step = speed * Time.deltaTime;
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, target, step);

            if (_camera.transform.position.x <= 0)
            {
                Left_button.SetActive(false);
            }
            else
            {
                Left_button.SetActive(true);
            }

            if (_camera.transform.position.x >= maxX)
            {
                Right_button.SetActive(false);
            }
            else
            {
                Right_button.SetActive(true);
            }
        }
    }

    private Action<T> Debounce<T>(Action<T> func, int milliseconds = 300)
    {
        CancellationTokenSource cancelTokenSource = null;

        return arg =>
        {
            cancelTokenSource?.Cancel();
            cancelTokenSource = new CancellationTokenSource();

            Task.Delay(milliseconds, cancelTokenSource.Token)
                .ContinueWith(t =>
                {
                    if (t.IsCompleted)
                    {
                        func(arg);
                    }
                }, TaskScheduler.Default);
        };
    }
}
