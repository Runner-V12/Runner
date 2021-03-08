using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameObject player;
    static public Vector3 playerStartPosition;
    private GameObject mainCamera;
    private GameObject[] EditUI;
    public static bool editMode = false;

    [SerializeField] private GameObject spawnPlayer;

    private GameObject[] triggerButtons;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStartPosition = player.transform.position;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        EditUI = GameObject.FindGameObjectsWithTag("EditUI");
        triggerButtons = GameObject.FindGameObjectsWithTag("TriggerButton");
    }

    private void Start()
    {
        ToggleEditing();
    }

    public void ToggleEditing()
    {
        if (editMode)
        {
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

            Instantiate(spawnPlayer, new Vector3(player.transform.position.x - Screen.width / Screen.dpi, player.transform.position.y, player.transform.position.z), Quaternion.identity);
        }
        else
        {
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
