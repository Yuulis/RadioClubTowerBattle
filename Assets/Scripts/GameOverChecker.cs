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
        if (collision.gameObject.tag == "FallingObjects")
        {
            gameManager.isGameOver = true;
            LoadNextScene("Scenes/GameOver");
        }
    }

    private void LoadNextScene(string scene)
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
                resultManager.score1 = gameManager.players[0].score;
                retryButtonManager.target = TargetScene.Solo;
            }
            else
            {
                resultManager.gameMode = "TwoPlayers";
                resultManager.score1 = gameManager.players[0].score;
                resultManager.score2 = gameManager.players[1].score;
                retryButtonManager.target = TargetScene.TwoPlayers;
            }

            SceneManager.sceneLoaded -= GameOverSceneLoaded;
        }
    }
}
