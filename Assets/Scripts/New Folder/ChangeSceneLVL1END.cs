using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneLVL1END : MonoBehaviour
{

    private void OnEnable()
    {
        SceneManager.LoadScene(15);
    }
}
