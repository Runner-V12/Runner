using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Grass : MonoBehaviour
{
    public enum SpriteSelection { Left, Mid, Right };

    [Header("Sprites available")]
    public Sprite Left;
    public Sprite Mid;
    public Sprite Right;

    [Header("Runtime Sprite Selection")]
    public SpriteSelection selection;


    private void Awake()
    {
        selection = SpriteSelection.Left;
    }
    private void Update()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            switch (selection)
            {
                case SpriteSelection.Left:
                    gameObject.GetComponent<SpriteRenderer>().sprite = Left;
                    break;
                case SpriteSelection.Mid:
                    gameObject.GetComponent<SpriteRenderer>().sprite = Mid;
                    break;
                case SpriteSelection.Right:
                    gameObject.GetComponent<SpriteRenderer>().sprite = Right;
                    break;
                default:
                    gameObject.GetComponent<SpriteRenderer>().sprite = Left;
                    break;
            }

        }
    }

}
