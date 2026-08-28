using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class ListContainer : MonoBehaviour
{
    public GameObject cardContainer;
    public GameObject cardPrefab;

    public TextMeshProUGUI debugInfo;
    public TextMeshProUGUI debugInfo2;
    public TextMeshProUGUI debugInfo3;

    struct Comment
    {
        public Comment(string icon, string name, string comment)
        {
            this.icon = icon;
            this.name = name;
            this.comment = comment;
        }
        public string icon { get; }
        public string name { get; }
        public string comment { get; }

        public override string ToString() => $"({icon}, {name}, {comment})";
    }

    void Awake()
    {
        DestroyDummyChildren();
    }

    void DestroyDummyChildren()
    {
        for (int i = 0; i < cardContainer.transform.childCount; i++)
        {
            Destroy(cardContainer.transform.GetChild(i).gameObject);
        }
    }

    List<Comment> comments = new List<Comment>();
    int currentIndex = 0;

    void Start()
    {
        //Debug.Log("Start");
        //Comment comment = new Comment("filename", "name", "comment");

        comments.Add(new Comment("hoge", "name1", "comment1")); 
        comments.Add(new Comment("fuga", "name2", "comment2"));
        comments.Add(new Comment("dirtgrass", "name3", "comment3"));
        comments.Add(new Comment("grass", "name4", "comment4"));
        comments.Add(new Comment("ohisama", "name5", "comment5"));
        comments.Add(new Comment("kasa", "name6", "comment6"));
        comments.Add(new Comment("kumo", "name7", "comment7"));
        
        for (int i = 0; i < 6; i++)
        {
            AddCard(comments[i]);
        }

        AddCard(comments[comments.Count - 1], 0);
        AddCard(comments[comments.Count - 2], 0);

        cardContainer.transform.position = transform.position + new Vector3(0, 102.0f * 2, 0);

        debugInfo.text = (transform.position.y - cardContainer.transform.position.y).ToString();
    }

    void AddCard(Comment comment, int index = int.MaxValue)
    {
        GameObject card = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);
        Card hoge = card.GetComponent<Card>();
        hoge.fileName = comment.icon;
        hoge.accountName = comment.name;
        hoge.comment = comment.comment;
        card.transform.SetParent(cardContainer.transform, false);
        
        if (index != int.MaxValue)
        {
            card.transform.SetSiblingIndex(index);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector3 pos = this.transform.position;
            Vector3 size = GetComponent<RectTransform>().sizeDelta;

            float left = pos.x - (size.x / 2);
            float right = pos.x + (size.x / 2);
            float top = pos.y + (size.y / 2);
            float bottom = pos.y - (size.y / 2);

            Vector2 leftTop = new Vector2(left, top);
            Vector2 rightBottom = new Vector2(right, bottom);

            //Debug.Log("hogya!" + " mousePos=" + mousePos + " leftTop=" + leftTop + " rightBottom=" + rightBottom);
        }
        
    }

    bool isDragStart = false;
    Vector3 prevMousePos = Vector3.zero;
    Vector3 startPos = Vector3.zero;

    public void OnBeginDrag()
    {
        prevMousePos = Input.mousePosition;
        startPos = cardContainer.transform.position;
    }

    public void OnDrag()
    {
        Vector3 currentMousPos = Input.mousePosition;
        Vector3 drag = (currentMousPos - prevMousePos);

        
        if (drag.y == 0) return;

        float mag = Mouse.current.delta.magnitude * 5f;

        cardContainer.transform.position += new Vector3(0, mag * Math.Sign(drag.y), 0);

        float dy = transform.position.y - cardContainer.transform.position.y;
        debugInfo.text = dy.ToString();

        InfinityScroll(dy);

        prevMousePos = Input.mousePosition;
    }

    public void OnEndDrag()
    {
        prevMousePos = Vector3.zero;
    }



    //public void OnScroll(BaseEventData bed)
    public void OnScroll()
    {
        float sensitive = 5f;
        Vector2 vec = Mouse.current.scroll.ReadValue();
        float mag = Mouse.current.scroll.magnitude * sensitive;

        cardContainer.transform.position -= new Vector3(0, mag * Math.Sign(vec.y), 0);
        float dy = transform.position.y - cardContainer.transform.position.y;
        debugInfo.text = dy.ToString();

        InfinityScroll(dy);
    }

    public void InfinityScroll(float dy)
    {
        if (dy < -204)
        {
            // 上限を超えたら一番上をひとつこわして一番下にひとつ追加
            Destroy(cardContainer.transform.GetChild(0).gameObject);


            AddCard(comments[(currentIndex + 6) % comments.Count]);

            cardContainer.transform.position = transform.position + new Vector3(0, 102.0f, 0);

            currentIndex = (currentIndex + 1) % comments.Count;
        } else if (dy > -102)
        {
            Destroy(cardContainer.transform.GetChild(7).gameObject);

            // 下限を超えたら一番下をひとつこわして一番上にひとつ追加
            int tmp = ((currentIndex + comments.Count) - (3 % comments.Count)) % comments.Count;
            //Debug.Log("currentIndex=" + currentIndex + " tmp=" + tmp);
            AddCard(comments[tmp], 0);
            
            cardContainer.transform.position = transform.position + new Vector3(0, 102.0f * 2, 0);

            currentIndex = (comments.Count + currentIndex - 1) % comments.Count;
        }
    }
}
