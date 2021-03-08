using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEditGamePanel : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    private Rigidbody2D playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public void Toggle()
    {
        _gameController.ToggleEditing();
        playerRigidbody.simulated = false;
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
        if (!GameController.editMode)
            playerRigidbody.simulated = true;
    }
}
