using UnityEngine;
using UnityEngine.UI;

public class ColorChanger3: MonoBehaviour
{
    public Image targetImage;
    public Color colorA = Color.red;
    public Color colorB = Color.blue;
    public float duration = 1.0f;

    private Color originalColor;

    void Start()
    {
        if (targetImage == null)
        {
            targetImage = GetComponent<Image>();
        }

        originalColor = targetImage.color;
        StartCoroutine(CycleColors());
    }

    System.Collections.IEnumerator CycleColors()
    {
        while (true)
        {
            yield return StartCoroutine(LerpColor(originalColor, colorA));
            yield return StartCoroutine(LerpColor(colorA, colorB));
            yield return StartCoroutine(LerpColor(colorB, originalColor));
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
