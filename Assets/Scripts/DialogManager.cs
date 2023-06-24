using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    public Image background;
    public TextMeshProUGUI dialogText;
    public Dialogue dialoguePriStarte;
    private Dialogue _dialogue;
    public GameObject DialogueUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DialogueUI.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        if (dialoguePriStarte != null)
            StartDialog(dialoguePriStarte); 
    }
    public void ContinueDialoeGUI()
    {
        if (_dialogue == null)
            return;

        _dialogue.ContinueDialogue();
    }

    public void StartDialog(Dialogue dialogue)
    {
        DialogueUI.SetActive(true);
        _dialogue = dialogue;
        dialogue.StartDialogue();
    }

    public void SetBackground(Sprite backgroundSprite)
    {
        // Установить текущее фоновое изображение
        if (backgroundSprite != null)
            background.sprite = backgroundSprite;

        background.gameObject.SetActive(background.sprite != null);
    }

    public void SetDialogText(string dialogText)
    {
        // Отобразить текст текущей ноды
        this.dialogText.text = dialogText;
    }

    public void PlayDialogSound(AudioClip dialogSound)
    {
        // Проиграть звук (если есть)
        AudioSource.PlayClipAtPoint(dialogSound, Vector3.zero);
    }

    internal void OnDialogueEnd()
    {
        background.gameObject.SetActive(false);
        background.sprite = null;
        DialogueUI.SetActive(false);
    }
}
