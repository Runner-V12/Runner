using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed = 30.0f;

    [SerializeField] private GameObject Left_button;
    [SerializeField] private GameObject Right_button;

    private GameObject _camera;
    private Vector3 target = new Vector3();

    private float maxX;
    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        target = _camera.transform.position;

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
        if (GetComponent<GameController>().editMode)
        {
            float step = speed * Time.deltaTime;
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, target, step);

            if (_camera.transform.position.x <= 0)
            {
                Left_button.GetComponent<Button>().enabled = false;
                Left_button.GetComponent<Image>().enabled = false;
            }
            else
            {
                Left_button.GetComponent<Button>().enabled = true;
                Left_button.GetComponent<Image>().enabled = true;
            }
            if (_camera.transform.position.x >= maxX)
            {
                Right_button.GetComponent<Button>().enabled = false;
                Right_button.GetComponent<Image>().enabled = false;
            }
            else
            {
                Right_button.GetComponent<Button>().enabled = true;
                Right_button.GetComponent<Image>().enabled = true;
            }
        }
    }
}
