using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [HideInInspector] public string gameMode;
    [HideInInspector] public int score;
    [HideInInspector] public int winnerId = -1;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI winnerText;

    void Start()
    {
        if (gameMode == "Solo")
        {
            scoreText.text = $"Score: {score}";
        }

        else
        {
            scoreText.text = "";

            if (winnerId == -1)
            {
                winnerText.text = "Draw!";
            }
            else
            {
                winnerText.text = $"{winnerId + 1}P Won!";
            }
        }
    }

    void Update()
    {
        
    }
}
