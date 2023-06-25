using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefResolution : MonoBehaviour
{
    public int targetWidth = 800;  // �������� ������ ������
    public int targetHeight = 600; // �������� ������ ������

    void Start()
    {
        // ��������� ���������� ������
        Screen.SetResolution(targetWidth, targetHeight, FullScreenMode.FullScreenWindow);
    }
}
