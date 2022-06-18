using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    [SerializeField]
    private Button buttonStart;
    [SerializeField]
    private Button buttonEnd;

    private void Awake()
    {
        if (buttonStart != null)
        {
            buttonStart.onClick.AddListener(StartGame);
        }
        if (buttonEnd != null)
        {
            buttonEnd.onClick.AddListener(QuitGame);
        }
        
    }
    private void StartGame()
    {
        SceneManager.LoadScene("_Scene_Hat");
    }

    private void QuitGame()
    {
        Application.Quit();
    }
    
}
