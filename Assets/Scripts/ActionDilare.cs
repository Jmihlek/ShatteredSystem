using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionDilare : MonoBehaviour
{
    public float delay = 1f; // Задержка в секундах
    public UnityEvent delayedEvent; // Событие, которое будет выполнено с задержкой

    private bool isDelaying = false; // Флаг, указывающий, выполняется ли задержка
    private float delayTimer = 0f; // Таймер задержки

    private void Update()
    {
        if (isDelaying)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= delay)
            {
                delayedEvent.Invoke(); // Вызов события после задержки
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
