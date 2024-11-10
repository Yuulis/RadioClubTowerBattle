using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Collections;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool isGameOver = false;
    public int currentTurn = 0;
    [SerializeField] PlayerManager player_1;
    [SerializeField] PlayerManager player_2;

    private void Start()
    {
        currentTurn = 1;

        TurnBegin();
}

    private void Update()
    {
        if (currentTurn == 1 && player_1.isMyObjFallen)
        {
            TurnEnd();
        }
        else if (currentTurn == 2 && player_2.isMyObjFallen)
        {
            TurnEnd();
        }
    }

    private void TurnBegin()
    {
        if (currentTurn == 1)
        {
            player_1.BeginMyTurn();
        }
        else if (currentTurn == 2)
        {
            player_2.BeginMyTurn();
        }
    }

    private void TurnEnd()
    {
        if (currentTurn == 1)
        {
            player_1.EndMyTurn();
        }
        else if (currentTurn == 2)
        {
            player_2.EndMyTurn();
        }

        currentTurn++;
        if (currentTurn >= 3)
        {
            currentTurn = 1;
        }

        TurnBegin();
    }
}