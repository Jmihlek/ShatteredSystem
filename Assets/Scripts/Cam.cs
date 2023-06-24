using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Cam : MonoBehaviour
{
    public GameObject CameraOne;
    public GameObject CameraTwo;
    public bool CamOn = false;
    public int CameraNumber;
    // Start is called before the first frame update
    void Start()
    {
        CameraNumber = 1;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CameraTwo.SetActive(true);
            CameraOne.SetActive(false);
        }
    }
}
