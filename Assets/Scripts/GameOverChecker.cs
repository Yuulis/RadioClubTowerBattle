using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverChecker : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.isGameOver = true;
        LoadNextScene("Scenes/GameOver", (gameManager.currentTurn + 1) % 2);
    }

    private void LoadNextScene(string scene, int player_id)
    {
        SceneManager.sceneLoaded += GameOverSceneLoaded;
        SceneManager.LoadScene("Scenes/GameOver");

        void GameOverSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            ResultManager resultManager = GameObject.FindWithTag("ResultManager").GetComponent<ResultManager>();
            SceneTransitionButtonManager retryButtonManager = GameObject.FindWithTag("RetryButton").GetComponent<SceneTransitionButtonManager>();

            if (gameManager.players.Count == 1)
            {
                resultManager.gameMode = "Solo";
                resultManager.score = gameManager.score;
                retryButtonManager.target = TargetScene.Solo;
            }
            else
            {
                resultManager.gameMode = "TwoPlayers";
                resultManager.score = gameManager.score;
                retryButtonManager.target = TargetScene.TwoPlayers;
                resultManager.winnerId = player_id;
            }

            SceneManager.sceneLoaded -= GameOverSceneLoaded;
        }
    }
}
