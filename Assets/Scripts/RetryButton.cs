using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void retry_button_clicked()
    {
        SceneManager.LoadScene("Scenes/Main");
    }

    public void retry_button()
    {
        Debug.Log("Credits Button Clicked");
    }
}
