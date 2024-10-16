using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene("Scenes/GameOver");
        }
    }
}
