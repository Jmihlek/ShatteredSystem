using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kwez : MonoBehaviour
{
    public Texture2D cursorTexture;
    private const string EvilKey = "IsEvil";

    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void SetEvil()
    {
        PlayerPrefs.SetInt(EvilKey, 1);
        PlayerPrefs.Save();
        Debug.Log("Монстр стал злым.");
    }

    public void ClearEvil()
    {
        PlayerPrefs.DeleteKey(EvilKey);
        PlayerPrefs.Save();
        Debug.Log("Монстр больше не злой.");
    }
}
