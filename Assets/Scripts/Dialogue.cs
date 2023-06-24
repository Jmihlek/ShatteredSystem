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

        // Установить текущее фоновое изображение
        DialogManager.instance.SetBackground(currentDialogNode.backgroundSprite);

        // Отобразить текст текущей ноды
        DialogManager.instance.SetDialogText(currentDialogNode.dialogText);

        // Проиграть звук (если есть)
        if (currentDialogNode.dialogSound != null)
        {
            DialogManager.instance.PlayDialogSound(currentDialogNode.dialogSound);
        }

        // Вызвать событие диалога (если есть)
        if (currentDialogNode.dialogEvent != null)
        {
            currentDialogNode.dialogEvent.Invoke();
        }
    }

    private void EndDialogue()
    {
        // Завершение диалога
        Debug.Log("Диалог завершен.");
        DialogManager.instance.OnDialogueEnd();
    }

}
