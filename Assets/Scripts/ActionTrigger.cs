using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ActionTrigger : MonoBehaviour
{
    public GameObject messageText;
    private bool isInTrigger = false;
    public UnityEvent Action;
    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }
    private void Update()
    {
        if (isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            // Выполнить действие при нажатии определенной кнопки в триггере
            Action?.Invoke();
            messageText.gameObject.SetActive(false); // Скрыть надпись
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Move>(out var Player))
        {
            isInTrigger = true;
            messageText.gameObject.SetActive(true); 
        }    
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Move>(out var Player))
        {
            isInTrigger = false;
            messageText.gameObject.SetActive(false); // Скрыть надпись
        }
    }
}
