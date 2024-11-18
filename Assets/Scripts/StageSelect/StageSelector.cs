using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum StageType
{
    Solo = 1,
    Test = 2,
    TwoPlayers = 3,
    Collection = 4,
}

public class StageSelector : MonoBehaviour
{

    public StageType stageType;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene($"Scenes/{stageType}");
    }
}
