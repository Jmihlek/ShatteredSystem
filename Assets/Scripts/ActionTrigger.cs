using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ActionTrigger : MonoBehaviour
{
    public int ID;
    public bool ActivateOnlyEnter;
    public GameObject messageText;
    private bool isInTrigger = false;
    public UnityEvent Action;
    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    public void DisableOnLoad()
    {
        PlayerPrefs.SetInt("TriggerID", ID);
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
        if (other.TryGetComponent<BasePlayer>(out var Player))
        {
            if (ActivateOnlyEnter)
            {
               Action?.Invoke();
                return;
            }
            isInTrigger = true;
            messageText.gameObject.SetActive(true); 
        }    
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<BasePlayer>(out var Player))
        {
            isInTrigger = false;
            if (messageText != null)
                messageText.gameObject.SetActive(false); // Скрыть надпись
        }
    }
}
