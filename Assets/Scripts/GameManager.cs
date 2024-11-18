using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Collections;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public List<PlayerManager> players;
    [HideInInspector] public bool isGameOver;
    [HideInInspector] public int currentTurn;

    private void Start()
    {
        isGameOver = false;
        currentTurn = 0;

        TurnBegin();
    }

    private void Update()
    {
        if (players[currentTurn].isMyObjFallen)
        {
            TurnEnd();
        }
    }

    private void TurnBegin()
    {
        players[currentTurn].BeginMyTurn();
    }

    private void TurnEnd()
    {
        players[currentTurn].EndMyTurn();

        currentTurn++;
        currentTurn %= players.Count;

        TurnBegin();
    }
}