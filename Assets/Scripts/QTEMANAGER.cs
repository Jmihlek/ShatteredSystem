using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QTEMANAGER : MonoBehaviour
{
    public KeyCode[] availableKeys; // ������ � ���������� ��������� ��� QTE
    public float displayTime = 1.0f; // ����� ����������� ����� �� ������
    public float inputTime = 0.5f; // �����, � ������� �������� ����� ������ ������ �� �������
    public TextMeshProUGUI KeyText;

    public UnityEvent onQTESuccess; // ������� ��� �������� ���������� QTE
    public UnityEvent onQTEFailure; // ������� ��� ������� QTE

    private bool qteActive = false;
    private KeyCode currentKey;

    private void Update()
    {
        if (qteActive)
        {
            if (Input.GetKeyDown(currentKey))
            {
                Debug.Log("������ ���������� �������!");
                QTESuccess();
            }
        }
    }

    public void StartQTE()
    {
        qteActive = true;
        currentKey = availableKeys[Random.Range(0, availableKeys.Length)];
        Debug.Log("������� �� �������: " + currentKey);
        KeyText.text = currentKey.ToString();
        KeyText.gameObject.SetActive(true);
        Invoke("QTEFailure", displayTime);
    }

    private void QTESuccess()
    {
        if (!qteActive)
            return;

        qteActive = false;
        Debug.Log("QTE ��������� �������.");
        // �������� ����� ���� ������ ��� ��������� ���������� QTE
        KeyText.gameObject.SetActive(false);
        onQTESuccess.Invoke();
    }

    private void QTEFailure()
    {
        if (!qteActive)
            return;

        qteActive = false;
        Debug.Log("QTE ���������.");
        // �������� ����� ���� ������ ��� ������� QTE
        KeyText.gameObject.SetActive(false);
        onQTEFailure.Invoke();
    }
}
