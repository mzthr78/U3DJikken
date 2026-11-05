using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class hoge : MonoBehaviour
{
    public int cameraIndex = 0;

    public Camera[] cameras;
    public RenderTexture renderTexture;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameras[0].gameObject.SetActive(true);
        cameras[0].targetTexture = renderTexture;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cameraIndex++;
            if (cameraIndex > 1)
            {
                cameraIndex = 0;
            }

            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].gameObject.SetActive(false);
                cameras[i].targetTexture = null;

                if (i == cameraIndex)
                {
                    cameras[i].gameObject.SetActive(true);
                    cameras[i].targetTexture = renderTexture;
                }
            }
        }
    }
}
