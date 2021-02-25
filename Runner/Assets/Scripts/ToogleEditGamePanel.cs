using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleEditGamePanel : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    private float _gravity;

    public void toogle() {
        _gameController.ToogleEditing();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().simulated = false;
    }

    public void desactivate() {
        this.gameObject.SetActive(false);
        if (!_gameController.editMode)
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().simulated = true;
    }
}
