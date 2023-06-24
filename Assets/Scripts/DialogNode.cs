using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DialogNode
{
    public Sprite backgroundSprite;
    public AudioClip dialogSound;
    public UnityEvent dialogEvent;
    public string dialogText;

}
