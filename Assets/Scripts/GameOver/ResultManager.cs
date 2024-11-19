using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [HideInInspector] public string gameMode;
    [HideInInspector] public int score1;
    [HideInInspector] public int score2;
    [SerializeField] private TextMeshProUGUI score1Text;
    [SerializeField] private TextMeshProUGUI score2Text;
    [SerializeField] private TextMeshProUGUI winnerText;

    void Start()
    {
        if (gameMode == "Solo")
        {
            score1Text.text = $"Score: {score1}";
        }

        else
        {
            score1Text.text = $"Player 1: {score1}";
            score2Text.text = $"Player 2: {score2}";

            if (score1 > score2)
            {
                winnerText.text = "Player 1 Wins!";
            }
            else if (score1 < score2)
            {
                winnerText.text = "Player 2 Wins!";
            }
            else
            {
                winnerText.text = "Draw!";
            }
        }
    }

    void Update()
    {
        
    }
}
