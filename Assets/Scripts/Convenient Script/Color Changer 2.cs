using UnityEngine;
using UnityEngine.UI;

public class ColorChanger2 : MonoBehaviour
{
    public Image targetImage;
    public Color targetColor = Color.red;
    public float duration = 1.0f;

    private Color originalColor;
    private bool isChanging = false;

    void Start()
    {
        if (targetImage == null)
        {
            targetImage = GetComponent<Image>();
        }

        originalColor = targetImage.color;
        StartCoroutine(ChangeColorLoop());
    }

    System.Collections.IEnumerator ChangeColorLoop()
    {
        while (true)
        {
            // 元の色からターゲットカラーへ
            yield return StartCoroutine(LerpColor(originalColor, targetColor));
            // ターゲットカラーから元の色へ
            yield return StartCoroutine(LerpColor(targetColor, originalColor));
        }
    }

    System.Collections.IEnumerator LerpColor(Color fromColor, Color toColor)
    {
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            targetImage.color = Color.Lerp(fromColor, toColor, time / duration);
            yield return null;
        }
        targetImage.color = toColor;
    }
}
