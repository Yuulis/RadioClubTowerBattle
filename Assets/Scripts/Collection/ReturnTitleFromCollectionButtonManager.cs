using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnTitleFromCollectionButtonManager : MonoBehaviour
{
    Button returnTitleButton;

    private void Start()
    {
        returnTitleButton = this.GetComponent<Button>();
        returnTitleButton.onClick.AddListener(OnClick);
    }

    private void Update()
    {

    }

    private void OnClick()
    {
        SceneManager.LoadScene("Scenes/StageSelect");
    }
}
