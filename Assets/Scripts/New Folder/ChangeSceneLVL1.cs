using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneLVL1 : MonoBehaviour
{

    private void OnEnable()
    {
        SceneManager.LoadScene(6);
    }
}
