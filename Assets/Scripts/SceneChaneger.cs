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
        var sceneid = SceneManager.GetActiveScene().buildIndex;
        var playerTransform = FindObjectOfType<BasePlayer>().transform;
        // ���������� ������� ������� � �������� ������
        var playerPosition = playerTransform.position;
        var playerRotation = playerTransform.rotation;

        // ���������� ������� � �������� � ���������� ������
        PlayerPrefs.SetFloat($"PlayerPositionX{sceneid}", playerPosition.x);
        PlayerPrefs.SetFloat($"PlayerPositionY{sceneid}", playerPosition.y);
        PlayerPrefs.SetFloat($"PlayerPositionZ{sceneid}", playerPosition.z);
                                              
        PlayerPrefs.SetFloat($"PlayerRotationX{sceneid}", playerRotation.x);
        PlayerPrefs.SetFloat($"PlayerRotationY{sceneid}", playerRotation.y);
        PlayerPrefs.SetFloat($"PlayerRotationZ{sceneid}", playerRotation.z);
        PlayerPrefs.SetFloat($"PlayerRotationW{sceneid}", playerRotation.w);

        // �������� ������ �����
        SceneManager.LoadScene(sceneIndex);
    }
}
