using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefResolution : MonoBehaviour
{
    public int targetWidth = 800;  // Желаемая ширина экрана
    public int targetHeight = 600; // Желаемая высота экрана

    void Start()
    {
        // Установка разрешения экрана
        Screen.SetResolution(targetWidth, targetHeight, FullScreenMode.FullScreenWindow);
    }
}
