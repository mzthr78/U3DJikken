using UnityEngine;
using UnityEngine.EventSystems;

public class button : MonoBehaviour
{
    public Camera[] cameras;
    public RenderTexture renderTexture;

    private int activeIndex = 0;

    [SerializeField] private int bIdx = 0;

    public void OnClick()
    {
        /*
        activeIndex++;
        if (activeIndex > cameras.Length - 1)
        {
            activeIndex = 0;
        }
        */

        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
            cameras[i].targetTexture = null;
        }

        /*
        cameras[activeIndex].gameObject.SetActive(true);
        cameras[activeIndex].targetTexture = renderTexture;
        */
        
        cameras[bIdx].gameObject.SetActive(true);
        cameras[bIdx].targetTexture = renderTexture;
    }
}
