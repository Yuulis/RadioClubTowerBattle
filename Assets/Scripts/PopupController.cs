using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject popupImage;
    public GameObject closeButton;
    public Sprite[] imageSprites;

    private UnityEngine.UI.Image popupImageComponent;


    // Start is called before the first frame update
    void Start()
    {
        popupImageComponent = popupImage.GetComponent<UnityEngine.UI.Image>();

        popupImage.SetActive(false);
        closeButton.SetActive(false);
    }

    public void ShowPopup(int imageIndex)
    {
        if(imageIndex >= 0 && imageIndex < imageSprites.Length)
        {
            popupImageComponent.sprite = imageSprites[imageIndex];
        }

        popupImage.SetActive(true);
        closeButton.SetActive(true);
    }

    public void ClosePopup()
    {
        popupImage.SetActive(false);
        closeButton.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
