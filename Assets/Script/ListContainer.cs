using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class ListContainer : MonoBehaviour
{
    public GameObject obj;
    
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

            Debug.Log("hogya!" + " mousePos=" + mousePos + " leftTop=" + leftTop + " rightBottom=" + rightBottom);
        }
        
    }

    bool isDragStart = false;
    Vector3 startMousePos = Vector3.zero;
    Vector3 startPos = Vector3.zero;

    public void OnBeginDrag()
    {
        startMousePos = Input.mousePosition;
        startPos = obj.transform.position;
    }

    public void OnDrag()
    {
        Vector3 currentMousPos = Input.mousePosition;
        Vector3 drag = (currentMousPos - startMousePos);
        
        if (drag.y != 0)
        {
            obj.transform.position = startPos + new Vector3(0, drag.y, 0);
        }
    }

    public void OnEndDrag()
    {
        startMousePos = Vector3.zero;
    }



    //public void OnScroll(BaseEventData bed)
    public void OnScroll()
    {
        float sensitive = 5f;
        Vector2 vec = Mouse.current.scroll.ReadValue();
        float mag = Mouse.current.scroll.magnitude * sensitive;
        Debug.Log("OnScroll y=" + vec.y + " maginitude=" + Mouse.current.scroll.magnitude);

        //obj.transform.position -= new Vector3(0, vec.y, 0);
        //Debug.Log("OnScroll" + data.position + " ");

        obj.transform.position -= new Vector3(0, mag * Math.Sign(vec.y), 0);
    }
}
