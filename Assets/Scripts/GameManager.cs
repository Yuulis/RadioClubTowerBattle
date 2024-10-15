using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Collections;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    [HideInInspector] public bool isGameOver = false;

    void Start()
    {
        UpdateScoreText();
    }

    void Update()
    {
        
    }

    void UpdateScoreText()
    {
        
    }
}