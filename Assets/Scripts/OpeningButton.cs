using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningButton : MonoBehaviour
{
    public void Opening_Button_Clicked()
    {
        SceneManager.LoadScene("Scenes/Opening");
    }

    public void Opening_Button()
    {
        Debug.Log("Credits Button Clicked");
    }
}
