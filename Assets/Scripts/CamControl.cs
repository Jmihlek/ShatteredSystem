using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset; // Смещение камеры относительно цели
    public float sensitivity = 2f; // Чувствительность мыши
    public float smoothing = 1f; // Сглаживание движения камеры

    private Vector2 mouseLook; // Вектор для хранения движения мыши
    private Vector2 smoothV; // Сглаженный вектор движения мыши

    void Update()
    {
        // Получаем движение мыши
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), 0f);

        // Умножаем движение мыши на чувствительность и сглаживание
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, 1f));

        // Используем сглаживание для плавного движения камеры
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);

        // Обновляем вектор движения мыши
        mouseLook += smoothV;

        // Поворачиваем камеру вокруг цели
        Quaternion rotation = Quaternion.Euler(0f, mouseLook.x, 0f);
        Vector3 position = playerTransform.position + rotation * offset;

        // Применяем поворот и позицию камеры
        transform.rotation = rotation;
        transform.position = position;
    }
}
