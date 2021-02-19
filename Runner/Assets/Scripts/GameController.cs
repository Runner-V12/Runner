using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // public bool paused = false;
    // [SerializeField] private Button pauseButton;
    // [SerializeField] private string pausedText = "Play";
    // [SerializeField] private string playingText = "Pause";

    private GameObject player;
    private GameObject playerStart;
    private GameObject mainCamera;
    private GameObject background;
    private GameObject[] EditUI;
    public bool editMode = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStart = GameObject.FindGameObjectWithTag("PlayerStart");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        background = GameObject.FindGameObjectWithTag("Background");
        EditUI = GameObject.FindGameObjectsWithTag("EditUI");
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
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("TriggerButton"))
            {
                item.GetComponent<Button>().enabled = false;
                item.GetComponent<Image>().enabled = false;
            }
            foreach (GameObject item in EditUI)
            {
                item.GetComponent<Image>().enabled = false;
            }
            mainCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y * 2, mainCamera.transform.position.z);
            mainCamera.transform.SetParent(player.transform);
        }
        else
        {
            //background.GetComponent<SpriteRenderer>().material.SetFloat("Vector1_BD96FC95",0f);
            player.GetComponent<PlayerController>().reset();
            player.transform.position = new Vector3(playerStart.transform.position.x,playerStart.transform.position.y,playerStart.transform.position.z);
            player.GetComponent<Rigidbody2D>().simulated = false;
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Trigger"))
            {
                item.GetComponent<SpriteRenderer>().enabled = true;
            }
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("TriggerButton"))
            {
                item.GetComponent<Button>().enabled = true;
                item.GetComponent<Image>().enabled = true;
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

    private Vector2 moveobject(Transform source, Transform destination, float speed)
    {
        return Vector2.MoveTowards(source.position,destination.position,speed);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
