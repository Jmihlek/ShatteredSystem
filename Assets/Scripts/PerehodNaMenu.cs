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
        // ����� �����������
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        // �������� �������� ���������� FirstLoad �� ���������� ������
        firstLoad = PlayerPrefs.GetInt(FirstLoadKey, 1) == 1;

        // ��������, � ������ �� ��� ����������� ����
        if (firstLoad)
        {
            Debug.Log("������ ������ ����");
            // ���������� �������� ��� ������ ������� ����

            // ���������� �������� ���������� FirstLoad � ���������� ������
            PlayerPrefs.SetInt(FirstLoadKey, 0);
            PlayerPrefs.Save();
            // ������������� �� ������� loopPointReached
            videoPlayer.loopPointReached += OnVideoFinished;
        }
        else
        {
            Debug.Log("���� �������� �� � ������ ���");
            // ���������� �������� ��� ����������� �������� ����
            SceneManager.LoadScene(1);
        }

    }

    [ContextMenu("�������� ���������� FirstLoad")]
    private void ResetFirstLoad()
    {
        PlayerPrefs.DeleteKey(FirstLoadKey);
        PlayerPrefs.Save();
        firstLoad = true;
        Debug.Log("���������� FirstLoad ��������");
    }
}
