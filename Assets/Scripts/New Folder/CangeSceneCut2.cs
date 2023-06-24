using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CangeSceneCut2 : MonoBehaviour
{

    private void OnEnable()
    {
        SceneManager.LoadScene(5);
    }
}
