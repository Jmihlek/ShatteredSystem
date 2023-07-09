using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject Menu;
    public void Continue()
    {
        Menu.SetActive(false);
        Time.timeScale = 1.0f;

    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            Menu.gameObject.SetActive(true);
        }
    }
}

