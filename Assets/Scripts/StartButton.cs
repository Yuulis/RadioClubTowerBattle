using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void OnStartGameButtonClicked()
    {
        SceneManager.LoadScene("Scenes/Main"); 
    }

    public void OnCreditsButtonClicked()
    {
        Debug.Log("Credits Button Clicked");
    }
}
