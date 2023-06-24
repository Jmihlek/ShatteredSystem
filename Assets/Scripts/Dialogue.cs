using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public DialogNode[] dialogNodes;
    private int currentDialogIndex = 0;

    public void StartDialogue()
    {
        currentDialogIndex = 0;
        ShowCurrentDialogNode();
    }

    public void ContinueDialogue()
    {
        currentDialogIndex++;
        if (currentDialogIndex < dialogNodes.Length)
        {
            ShowCurrentDialogNode();
        }
        else
        {
            EndDialogue();
        }
    }

    private void ShowCurrentDialogNode()
    {
        DialogNode currentDialogNode = dialogNodes[currentDialogIndex];

        // ���������� ������� ������� �����������
        DialogManager.instance.SetBackground(currentDialogNode.backgroundSprite);

        // ���������� ����� ������� ����
        DialogManager.instance.SetDialogText(currentDialogNode.dialogText);

        // ��������� ���� (���� ����)
        if (currentDialogNode.dialogSound != null)
        {
            DialogManager.instance.PlayDialogSound(currentDialogNode.dialogSound);
        }

        // ������� ������� ������� (���� ����)
        if (currentDialogNode.dialogEvent != null)
        {
            currentDialogNode.dialogEvent.Invoke();
        }
    }

    private void EndDialogue()
    {
        // ���������� �������
        Debug.Log("������ ��������.");
        DialogManager.instance.OnDialogueEnd();
    }

}
