using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zaderjka : MonoBehaviour
{
    public GameObject[] targetObjects; // ������ ������� �������� ��� ���������
    public float delayTime = 2f; // �������� ����� ���������� � ��������

    private void Start()
    {
        // ��������� �������� ��� �������� ���������
        StartCoroutine(ActivateObjectsDelayedCoroutine());
    }

    private System.Collections.IEnumerator ActivateObjectsDelayedCoroutine()
    {
        // ���� �������� �����
        yield return new WaitForSeconds(delayTime);

        // ���������� ������ ������ � �������
        for (int i = 0; i < targetObjects.Length; i++)
        {
            targetObjects[i].SetActive(true);
        }
    }
}
