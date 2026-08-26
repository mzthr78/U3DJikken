using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titlebutton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("button dayo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
