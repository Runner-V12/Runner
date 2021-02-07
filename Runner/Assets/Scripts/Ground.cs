using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Ground : MonoBehaviour
{

    #region struct and class

    public enum SpriteType { Spring, Autumn, Winter, Dirt };
    public enum SpriteDirection { Left, Mid, Right };

    [System.Serializable] // TO ALLOW DISPLAY IN INSPECTOR
    public class SpriteSelection
    {
        [SerializeField] public SpriteType spriteType;
        [SerializeField] public SpriteDirection direction;
    }

    [System.Serializable] // TO ALLOW DISPLAY IN INSPECTOR
    public class GroundSprites
    {
        [SerializeField] public Sprite Left;
        [SerializeField] public Sprite Mid;
        [SerializeField] public Sprite Right;
    }
    # endregion

    # region variables

    [Header("Sprites Bank")]
    [SerializeField] private GroundSprites Spring;
    [SerializeField] private GroundSprites Autumn;
    [SerializeField] private GroundSprites Winter;
    [SerializeField] private GroundSprites Dirt;

    [Header("Runtime Sprite Selection")]
    public SpriteSelection spriteSelection;

    # endregion

    private void Update()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            switch (spriteSelection)
            {
                //SPRING
                case SpriteSelection s when (s.direction == SpriteDirection.Left && s.spriteType == SpriteType.Spring):
                    gameObject.GetComponent<SpriteRenderer>().sprite = Spring.Left;
                    break;
                case SpriteSelection s when (s.direction == SpriteDirection.Mid && s.spriteType == SpriteType.Spring):
                    gameObject.GetComponent<SpriteRenderer>().sprite = Spring.Mid;
                    break;
                case SpriteSelection s when (s.direction == SpriteDirection.Right && s.spriteType == SpriteType.Spring):
                    gameObject.GetComponent<SpriteRenderer>().sprite = Spring.Right;
                    break;
                //AUTUMN
                case SpriteSelection s when (s.direction == SpriteDirection.Left && s.spriteType == SpriteType.Autumn):
                    gameObject.GetComponent<SpriteRenderer>().sprite = Autumn.Left;
                    break;
                case SpriteSelection s when (s.direction == SpriteDirection.Mid && s.spriteType == SpriteType.Autumn):
                    gameObject.GetComponent<SpriteRenderer>().sprite = Autumn.Mid;
                    break;
                case SpriteSelection s when (s.direction == SpriteDirection.Right && s.spriteType == SpriteType.Autumn):
                    gameObject.GetComponent<SpriteRenderer>().sprite = Autumn.Right;
                    break;
                //WINTER
                case SpriteSelection s when (s.direction == SpriteDirection.Left && s.spriteType == SpriteType.Winter):
                    gameObject.GetComponent<SpriteRenderer>().sprite = Winter.Left;
                    break;
                case SpriteSelection s when (s.direction == SpriteDirection.Mid && s.spriteType == SpriteType.Winter):
                    gameObject.GetComponent<SpriteRenderer>().sprite = Winter.Mid;
                    break;
                case SpriteSelection s when (s.direction == SpriteDirection.Right && s.spriteType == SpriteType.Winter):
                    gameObject.GetComponent<SpriteRenderer>().sprite = Winter.Right;
                    break;
                //DIRT
                case SpriteSelection s when (s.direction == SpriteDirection.Left && s.spriteType == SpriteType.Dirt):
                    gameObject.GetComponent<SpriteRenderer>().sprite = Dirt.Left;
                    break;
                case SpriteSelection s when (s.direction == SpriteDirection.Mid && s.spriteType == SpriteType.Dirt):
                    gameObject.GetComponent<SpriteRenderer>().sprite = Dirt.Mid;
                    break;
                case SpriteSelection s when (s.direction == SpriteDirection.Right && s.spriteType == SpriteType.Dirt):
                    gameObject.GetComponent<SpriteRenderer>().sprite = Dirt.Right;
                    break;
                //DEFAULT
                default:
                    gameObject.GetComponent<SpriteRenderer>().sprite = Spring.Left;
                    break;
            }

        }
    }
}
