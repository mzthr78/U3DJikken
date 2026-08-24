using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera userCamera;
    public Camera pcCamera;

    public Camera[] securityCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        userCamera.enabled = true;
        pcCamera.enabled = false;
        */
        EnableUserCamera(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void EnableUserCamera(Boolean b = true)
    {
        userCamera.enabled = b;
        pcCamera.enabled = !b;
    }
}

