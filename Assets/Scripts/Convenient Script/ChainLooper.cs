using UnityEngine;

public class ChainLooper : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 50f; // ピクセル/秒
    [SerializeField] private float resetPositionY = -800f; // 初期位置に戻すY座標
    [SerializeField] private float startPositionY = 800f;  // 初期Y位置（ループ戻り）

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.anchoredPosition += Vector2.down * scrollSpeed * Time.deltaTime;

        if (rectTransform.anchoredPosition.y <= resetPositionY)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, startPositionY);
        }
    }
}
