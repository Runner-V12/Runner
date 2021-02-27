using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerStartPosition;
    private GameObject playerStart;
    private GameObject mainCamera;
    private GameObject background;
    private GameObject[] EditUI;
    public static bool editMode = false;

    [SerializeField] private GameObject spawnPlayer;

    private GameObject[] triggerButtons;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStartPosition = player.transform.position;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        background = GameObject.FindGameObjectWithTag("Background");
        EditUI = GameObject.FindGameObjectsWithTag("EditUI");
        triggerButtons = GameObject.FindGameObjectsWithTag("TriggerButton");
        ToogleEditing();
    }

    public void ToogleEditing()
    {
        if (editMode)
        {
            //background.GetComponent<SpriteRenderer>().material.SetFloat("Vector1_BD96FC95",0.2f);
            player.GetComponent<PlayerController>().reset();
            player.GetComponent<Rigidbody2D>().simulated = true;
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Trigger"))
            {
                item.GetComponent<SpriteRenderer>().enabled = false;
            }
            foreach (var item in triggerButtons)
            {
                item.SetActive(false);

            }
            foreach (GameObject item in EditUI)
            {
                item.GetComponent<Image>().enabled = false;
            }
            mainCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y * 2, mainCamera.transform.position.z);
            mainCamera.transform.SetParent(player.transform);

            Instantiate(spawnPlayer);
        }
        else
        {
            //background.GetComponent<SpriteRenderer>().material.SetFloat("Vector1_BD96FC95",0f);
            player.GetComponent<PlayerController>().reset();
            player.transform.position = playerStartPosition;
            player.GetComponent<Rigidbody2D>().simulated = false;
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Trigger"))
            {
                item.GetComponent<SpriteRenderer>().enabled = true;
            }
            foreach (var item in triggerButtons)
            {
                item.SetActive(true);

            }
            foreach (GameObject item in EditUI)
            {
                item.GetComponent<Image>().enabled = true;
            }
            mainCamera.transform.position = new Vector3(0, 0, mainCamera.transform.position.z);
            mainCamera.transform.parent = null;
        }
        editMode = !editMode;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
