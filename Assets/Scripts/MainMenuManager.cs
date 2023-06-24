using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private const string IsGameStartedKey = "IsGameStarted";

    public GameObject continueButton;

    private void Start()
    {
        // Проверка, была ли игра уже начата
        bool isGameStarted = PlayerPrefs.GetInt(IsGameStartedKey, 0) == 1;

        // Отображение кнопки "Продолжить", если игра была уже начата
        continueButton.SetActive(isGameStarted);
    }

    public void NewGame()
    {
        // Установка переменной IsGameStarted в постоянной памяти
        PlayerPrefs.SetInt(IsGameStartedKey, 1);
        PlayerPrefs.Save();

        // Загрузка новой игры (например, первой сцены)
        SceneManager.LoadScene(2);
    }

    public void Creators()
    {
        // Загрузка сцены с информацией о создателях
        SceneManager.LoadScene("CreatorsScene");
    }

    public void ExitGame()
    {
        // Закрытие игры (работает только в сборке, не в редакторе Unity)
        Application.Quit();
    }

    [ContextMenu("Сбросить переменную IsGameStarted")]
    private void ResetIsGameStarted()
    {
        PlayerPrefs.DeleteKey(IsGameStartedKey);
        PlayerPrefs.Save();
        continueButton.SetActive(false);
        Debug.Log("Переменная IsGameStarted сброшена");
    }
}
