using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryButtonManager : MonoBehaviour
{
    Button retryButton;

    private void Start()
    {
        retryButton = this.GetComponent<Button>();
        retryButton.onClick.AddListener(OnClick);
    }

    private void Update()
    {

    }

    private void OnClick()
    {
        SceneManager.LoadScene("Scenes/Solo");
    }
}
