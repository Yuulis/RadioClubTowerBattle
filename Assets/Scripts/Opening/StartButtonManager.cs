using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtonManager : MonoBehaviour
{
    Button startButton;

    private void Start()
    {
        startButton = this.GetComponent<Button>();
        startButton.onClick.AddListener(OnClick);
    }

    private void Update()
    {
        
    }

    private void OnClick()
    {
        SceneManager.LoadScene("Scenes/StageSelect");
    }
}
