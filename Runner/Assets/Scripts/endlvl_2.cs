using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endlvl_2 : MonoBehaviour
{
    [SerializeField]private string NextLvlName;
    [SerializeField]private Text PanelLevelName;
    [SerializeField]private GameObject _Panel;


    private void OnTriggerEnter2D(Collider2D collision) {
        _Panel.SetActive(true);
        PanelLevelName.text = SceneManager.GetActiveScene().name;
    }

    public void changeLVL() {
        SceneManager.LoadScene(NextLvlName,LoadSceneMode.Single);
    }
}
