using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QTEMANAGER : MonoBehaviour
{
    public KeyCode[] availableKeys; // Массив с доступными клавишами для QTE
    public float displayTime = 1.0f; // Время отображения буквы на экране
    public float inputTime = 0.5f; // Время, в течение которого игрок должен нажать на клавишу
    public TextMeshProUGUI KeyText;

    public UnityEvent onQTESuccess; // Событие при успешном выполнении QTE
    public UnityEvent onQTEFailure; // Событие при провале QTE

    private bool qteActive = false;
    private KeyCode currentKey;

    private void Update()
    {
        if (qteActive)
        {
            if (Input.GetKeyDown(currentKey))
            {
                Debug.Log("Нажата правильная клавиша!");
                QTESuccess();
            }
        }
    }

    public void StartQTE()
    {
        qteActive = true;
        currentKey = availableKeys[Random.Range(0, availableKeys.Length)];
        Debug.Log("Нажмите на клавишу: " + currentKey);
        KeyText.text = currentKey.ToString();
        KeyText.gameObject.SetActive(true);
        Invoke("QTEFailure", displayTime);
    }

    private void QTESuccess()
    {
        if (!qteActive)
            return;

        qteActive = false;
        Debug.Log("QTE выполнено успешно.");
        // Добавьте здесь свою логику для успешного выполнения QTE
        KeyText.gameObject.SetActive(false);
        onQTESuccess.Invoke();
    }

    private void QTEFailure()
    {
        if (!qteActive)
            return;

        qteActive = false;
        Debug.Log("QTE провалено.");
        // Добавьте здесь свою логику для провала QTE
        KeyText.gameObject.SetActive(false);
        onQTEFailure.Invoke();
    }
}
