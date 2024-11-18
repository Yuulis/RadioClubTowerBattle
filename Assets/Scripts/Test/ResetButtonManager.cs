using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetButtonManager : MonoBehaviour
{
    Button resetButton;

    private void Start()
    {
        resetButton = this.GetComponent<Button>();
        resetButton.onClick.AddListener(OnClick);
    }

    private void Update()
    {

    }

    private void OnClick()
    {
        SceneManager.LoadScene("Scenes/Test");
    }
}
