using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionDilare : MonoBehaviour
{
    public float delay = 1f; // �������� � ��������
    public UnityEvent delayedEvent; // �������, ������� ����� ��������� � ���������

    private bool isDelaying = false; // ����, �����������, ����������� �� ��������
    private float delayTimer = 0f; // ������ ��������

    private void Update()
    {
        if (isDelaying)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= delay)
            {
                delayedEvent.Invoke(); // ����� ������� ����� ��������
                ResetDelay();
            }
        }
    }

    public void StartDelay()
    {
        isDelaying = true;
    }

    public void ResetDelay()
    {
        isDelaying = false;
        delayTimer = 0f;
    }
}
