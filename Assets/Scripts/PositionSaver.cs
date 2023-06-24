using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PositionSaver : MonoBehaviour
{
    private Move playerMove;
    private Vector3 playerPosition;
    private Quaternion playerRotation;

    private void Start()
    {
        // ����� ������ � ����������� Move
        playerMove = FindObjectOfType<Move>();
        var cameras = FindObjectsOfType<Camera>();

        // �������� ������� ����������� ������� � ��������
        if (PlayerPrefs.HasKey("PlayerPositionX") && PlayerPrefs.HasKey("PlayerPositionY") && PlayerPrefs.HasKey("PlayerPositionZ") &&
            PlayerPrefs.HasKey("PlayerRotationX") && PlayerPrefs.HasKey("PlayerRotationY") && PlayerPrefs.HasKey("PlayerRotationZ") && 
            PlayerPrefs.HasKey("PlayerRotationW"))
        {
            // �������� ����������� ������� � ��������
            float posX = PlayerPrefs.GetFloat("PlayerPositionX");
            float posY = PlayerPrefs.GetFloat("PlayerPositionY");
            float posZ = PlayerPrefs.GetFloat("PlayerPositionZ");
            playerPosition = new Vector3(posX, posY, posZ);

            float rotX = PlayerPrefs.GetFloat("PlayerRotationX");
            float rotY = PlayerPrefs.GetFloat("PlayerRotationY");
            float rotZ = PlayerPrefs.GetFloat("PlayerRotationZ");
            float rotW = PlayerPrefs.GetFloat("PlayerRotationW");
            playerRotation = new Quaternion(rotX, rotY, rotZ, rotW);

            // ����������� ������ � ����������� ������� � �������
            playerMove.transform.position = playerPosition;
            playerMove.transform.rotation = playerRotation;
            // ����� ��������� ������ � ����������� "Move"
            Camera closestCamera = FindClosestCamera(playerPosition);
            if (closestCamera != null)
            { 
                foreach (var item in cameras)
                    item.gameObject.SetActive(false);   

                // �������� � ��������� �������
                // ��������, ��������� �� � �������� �������� ������
                closestCamera.gameObject.SetActive(true);
            }
        }

    }

    private Camera FindClosestCamera(Vector3 targetPosition)
    {
        Camera[] cameras = FindObjectsOfType<Camera>(true);
        Camera closestCamera = null;
        float closestDistance = Mathf.Infinity;

        foreach (Camera camera in cameras)
        {
            float distance = Vector3.Distance(camera.transform.position, targetPosition);
            if (distance < closestDistance)
            {
                closestCamera = camera;
                closestDistance = distance;
            }
        }

        return closestCamera;
    }

    [ContextMenu("Reset Saved Variables")]
    private void ResetSavedVariables()
    {
        // �������� ���� ����������� ����������
        PlayerPrefs.DeleteKey("PlayerPositionX");
        PlayerPrefs.DeleteKey("PlayerPositionY");
        PlayerPrefs.DeleteKey("PlayerPositionZ");

        PlayerPrefs.DeleteKey("PlayerRotationX");
        PlayerPrefs.DeleteKey("PlayerRotationY");
        PlayerPrefs.DeleteKey("PlayerRotationZ");
        PlayerPrefs.DeleteKey("PlayerRotationW");

        Debug.Log("Saved variables reset.");
    }
}
