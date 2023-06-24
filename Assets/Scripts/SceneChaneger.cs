using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChaneger : MonoBehaviour
{
    public void ChangeSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void ChangeSceneByIndexPosition(int sceneIndex)
    {
        var playerTransform = FindObjectOfType<Move>().transform;
        // ���������� ������� ������� � �������� ������
        var playerPosition = playerTransform.position;
        var playerRotation = playerTransform.rotation;

        // ���������� ������� � �������� � ���������� ������
        PlayerPrefs.SetFloat("PlayerPositionX", playerPosition.x);
        PlayerPrefs.SetFloat("PlayerPositionY", playerPosition.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", playerPosition.z);

        PlayerPrefs.SetFloat("PlayerRotationX", playerRotation.x);
        PlayerPrefs.SetFloat("PlayerRotationY", playerRotation.y);
        PlayerPrefs.SetFloat("PlayerRotationZ", playerRotation.z);
        PlayerPrefs.SetFloat("PlayerRotationW", playerRotation.w);

        // �������� ������ �����
        SceneManager.LoadScene(sceneIndex);
    }
}
