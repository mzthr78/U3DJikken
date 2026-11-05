using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("hoge");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            Debug.Log("O");
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void hoge()
    {
        Debug.Log("n?");
        SceneManager.LoadScene("SampleScene");
    }
}
