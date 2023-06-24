using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset; // �������� ������ ������������ ����
    public float sensitivity = 2f; // ���������������� ����
    public float smoothing = 1f; // ����������� �������� ������

    private Vector2 mouseLook; // ������ ��� �������� �������� ����
    private Vector2 smoothV; // ���������� ������ �������� ����

    void Update()
    {
        // �������� �������� ����
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), 0f);

        // �������� �������� ���� �� ���������������� � �����������
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, 1f));

        // ���������� ����������� ��� �������� �������� ������
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);

        // ��������� ������ �������� ����
        mouseLook += smoothV;

        // ������������ ������ ������ ����
        Quaternion rotation = Quaternion.Euler(0f, mouseLook.x, 0f);
        Vector3 position = playerTransform.position + rotation * offset;

        // ��������� ������� � ������� ������
        transform.rotation = rotation;
        transform.position = position;
    }
}
