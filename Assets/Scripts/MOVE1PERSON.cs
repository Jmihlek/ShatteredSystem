using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVE1PERSON : BasePlayer
{
    public float speed = 5f;  // �������� �����������

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // �������� ���� �� ���� ��������������� � ������������� ����������� (WASD, ������� � �.�.)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ��������� ����������� �������� ������������ ������
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0f;  // ���������� ������������ ���
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // ��������� ������ �����������
        Vector3 desiredMoveDirection = forward * verticalInput + right * horizontalInput;
        moveDirection = desiredMoveDirection * speed;

        // ��������� ����������
        moveDirection.y -= 9.81f * Time.deltaTime;

        // ���������� ��������
        controller.Move(moveDirection * Time.deltaTime);
    }
}
