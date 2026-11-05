using System;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class SecuritySystem : MonoBehaviour
{
    public GameObject player;
    public Camera userCamera;
    public Camera pcCamera;
    public Canvas pcCanvas;

    Boolean isClose = false;
    Boolean isOperation = false;
    
    void Update()
    {
        if (isClose)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOperation = !isOperation;

                Debug.Log("Fuga! isOperation=" + isOperation);
                // カーソル表示・ロック の切り替え
                // カメラの切り替え

                if (isOperation)
                {

                    player.SetActive(false);
                    userCamera.enabled = false;
                    pcCamera.enabled = true;

                    pcCanvas.worldCamera = pcCamera;

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                } else
                {
                    player.SetActive(true);
                    userCamera.enabled = true;
                    pcCamera.enabled = false;

                    pcCanvas.worldCamera = userCamera;

                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        isClose = true;
    }

    void OTriggerExit(Collider other)
    {
        isClose = false;
    }
}
