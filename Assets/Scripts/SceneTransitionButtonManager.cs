using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum TargetScene
{
    Title = 1,
    StageSelect = 2,
    GameOver = 3,
    Solo = 4,
    TwoPlayers = 5,
    Test = 6,
    Collection = 7,
}

public class SceneTransitionButtonManager : MonoBehaviour
{
    public TargetScene target;
    private Button button;

    private void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void Update()
    {

    }

    private void OnClick()
    {
        SceneManager.LoadScene($"Scenes/{target}");
    }
}
