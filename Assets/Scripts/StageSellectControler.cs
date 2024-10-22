using UnityEngine;
using UnityEngine.UI;

public class StageSelectController : MonoBehaviour
{
    public ScrollRect scrollRect;  
    public float scrollSpeed = 0.2f;  

    public void OnLeftArrowClick()
    {
        float newPosition = Mathf.Clamp(scrollRect.horizontalNormalizedPosition - scrollSpeed, 0f, 1f);
        scrollRect.horizontalNormalizedPosition = newPosition;
    }

    public void OnRightArrowClick()
    {
        float newPosition = Mathf.Clamp(scrollRect.horizontalNormalizedPosition + scrollSpeed, 0f, 1f);
        scrollRect.horizontalNormalizedPosition = newPosition;
    }
}
