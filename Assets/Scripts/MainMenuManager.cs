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
        // ��������, ���� �� ���� ��� ������
        bool isGameStarted = PlayerPrefs.GetInt(IsGameStartedKey, 0) == 1;

        // ����������� ������ "����������", ���� ���� ���� ��� ������
        continueButton.SetActive(isGameStarted);
    }

    public void NewGame()
    {
        // ��������� ���������� IsGameStarted � ���������� ������
        PlayerPrefs.SetInt(IsGameStartedKey, 1);
        PlayerPrefs.Save();

        // �������� ����� ���� (��������, ������ �����)
        SceneManager.LoadScene(2);
    }

    public void Creators()
    {
        // �������� ����� � ����������� � ����������
        SceneManager.LoadScene("CreatorsScene");
    }

    public void ExitGame()
    {
        // �������� ���� (�������� ������ � ������, �� � ��������� Unity)
        Application.Quit();
    }

    [ContextMenu("�������� ���������� IsGameStarted")]
    private void ResetIsGameStarted()
    {
        PlayerPrefs.DeleteKey(IsGameStartedKey);
        PlayerPrefs.Save();
        continueButton.SetActive(false);
        Debug.Log("���������� IsGameStarted ��������");
    }
}
