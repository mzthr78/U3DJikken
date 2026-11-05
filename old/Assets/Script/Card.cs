using System;
using Mono.Cecil;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] RawImage icon;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI commentText;

    public String fileName = "";
    public String accountName = "name";
    public String comment = "comment";

    public Card(string file, string accoutName, string comment)
    {
        this.fileName = file;
        this.accountName = accoutName;
        this.comment = comment;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("filename=" + this.fileName);
        icon.texture = Resources.Load<Texture>("Image/" + this.fileName);
        nameText.text = this.accountName;
        commentText.text = this.comment;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
