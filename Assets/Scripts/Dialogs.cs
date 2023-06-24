using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogs : MonoBehaviour
{
    public string[] lines;
    public float speedText;
    public Text dialogeText;

    public int index;

    private void Start()
    {
        dialogeText.text = string.Empty; 
        StartDialouge();
    }

    void StartDialouge()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            dialogeText.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    public void scipTextClick()
    {
        if(dialogeText.text == lines[index])
        {
            NextLines();
        }
        else
            StopAllCoroutines();
        dialogeText.text = lines[index];
    }

    private void NextLines()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogeText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
