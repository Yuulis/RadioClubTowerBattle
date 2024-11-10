using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public void OnResetGameButtonClicked()
    {
        SceneManager.LoadScene("Scenes/TestStage");
    }

   
}
