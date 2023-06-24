using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PerehodNaMenu : MonoBehaviour
{
    private const string FirstLoadKey = "FirstLoad";

    [SerializeField]
    private bool firstLoad = true;
    public VideoPlayer videoPlayer;

    private void OnVideoFinished(VideoPlayer player)
    {
        // Видео завершилось
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        // Загрузка значения переменной FirstLoad из постоянной памяти
        firstLoad = PlayerPrefs.GetInt(FirstLoadKey, 1) == 1;

        // Проверка, в первый ли раз запускается игра
        if (firstLoad)
        {
            Debug.Log("Первый запуск игры");
            // Выполнение действий при первом запуске игры

            // Сохранение значения переменной FirstLoad в постоянной памяти
            PlayerPrefs.SetInt(FirstLoadKey, 0);
            PlayerPrefs.Save();
            // Подписываемся на событие loopPointReached
            videoPlayer.loopPointReached += OnVideoFinished;
        }
        else
        {
            Debug.Log("Игра запущена не в первый раз");
            // Выполнение действий при последующих запусках игры
            SceneManager.LoadScene(1);
        }

    }

    [ContextMenu("Сбросить переменную FirstLoad")]
    private void ResetFirstLoad()
    {
        PlayerPrefs.DeleteKey(FirstLoadKey);
        PlayerPrefs.Save();
        firstLoad = true;
        Debug.Log("Переменная FirstLoad сброшена");
    }
}
