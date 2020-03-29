using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : MonoBehaviour
{
    public GameObject newGamePanel;
    public GameObject loadGamePanel;
    public GameObject joinGamePanel;

    public void NewGame()
    {
        newGamePanel.SetActive(true);
        gameObject.SetActive(false);
    }
    public void LoadGame()
    {
        loadGamePanel.SetActive(true);
        gameObject.SetActive(false);
    }
    public void JoinGame()
    {
        joinGamePanel.SetActive(true);
        gameObject.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
