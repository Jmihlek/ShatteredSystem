using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zaderjka : MonoBehaviour
{
    public GameObject[] targetObjects; // Массив целевых объектов для активации
    public float delayTime = 2f; // Задержка перед активацией в секундах

    private void Start()
    {
        // Запускаем корутину для задержки активации
        StartCoroutine(ActivateObjectsDelayedCoroutine());
    }

    private System.Collections.IEnumerator ActivateObjectsDelayedCoroutine()
    {
        // Ждем заданное время
        yield return new WaitForSeconds(delayTime);

        // Активируем каждый объект в массиве
        for (int i = 0; i < targetObjects.Length; i++)
        {
            targetObjects[i].SetActive(true);
        }
    }
}
