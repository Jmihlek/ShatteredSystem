using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVE1PERSON : BasePlayer
{
    public float speed = 5f;  // Скорость перемещения

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Получаем ввод от осей горизонтального и вертикального перемещения (WASD, стрелки и т.д.)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Вычисляем направление движения относительно камеры
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0f;  // Игнорируем вертикальную ось
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Вычисляем вектор перемещения
        Vector3 desiredMoveDirection = forward * verticalInput + right * horizontalInput;
        moveDirection = desiredMoveDirection * speed;

        // Применяем гравитацию
        moveDirection.y -= 9.81f * Time.deltaTime;

        // Перемещаем персонаж
        controller.Move(moveDirection * Time.deltaTime);
    }
}
