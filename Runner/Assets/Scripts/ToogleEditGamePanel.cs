using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleEditGamePanel : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    private float _gravity;

    private Rigidbody2D playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public void toogle() {
        _gameController.ToogleEditing();
        playerRigidbody.simulated = false;
    }

    public void desactivate() {
        this.gameObject.SetActive(false);
        if (!GameController.editMode)
            playerRigidbody.simulated = true;
    }
}
