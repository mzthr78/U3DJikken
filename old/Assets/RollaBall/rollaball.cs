using System;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class rollaball : MonoBehaviour
{
    [SerializeField] GameObject collectiblePrefab;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI leftText;
    [SerializeField] TextMeshProUGUI clearText;
    public int count = 8;

    void Awake()
    {
        clearText.enabled = false;

        for (int i = 0; i < count; i++)
        {
            GameObject tmp = Instantiate(collectiblePrefab, new Vector3(0, 0.5f, 4.5f), Quaternion.identity);
            tmp.transform.RotateAround(Vector3.zero, Vector3.up, 360 / count * i);
        }
    }

    public void DecCount()
    {
        count -= 1;

        /*
        if (count <= 0)
        {
            Time.timeScale = 0;
        }
        */
    }

    void Update()
    {
        leftText.text = count.ToString();

        if (count <= 0) {
            clearText.enabled = true;
            return;
        }

        timeText.text = Time.time.ToString();
    }
}
