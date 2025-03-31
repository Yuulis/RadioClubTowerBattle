using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageSwitcher : MonoBehaviour
{
    public Image targetImage;             
    public Sprite[] sprites;              
    public float interval = 0.5f;         

    private int currentIndex = 0;

    void Start()
    {
        if (targetImage == null || sprites.Length == 0)
        {
            Debug.LogWarning("ImageSwitcher: ImageÇ‹ÇΩÇÕSpritesÇ™ê›íËÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒ");
            return;
        }

        StartCoroutine(SwitchImages());
    }

    IEnumerator SwitchImages()
    {
        while (true)
        {
            targetImage.sprite = sprites[currentIndex];
            currentIndex = (currentIndex + 1) % sprites.Length;
            yield return new WaitForSeconds(interval);
        }
    }
}
