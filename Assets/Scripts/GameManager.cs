using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Collections;
using Random = UnityEngine.Random;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<PlayerManager> players;
    [HideInInspector] public bool isGameOver;
    [HideInInspector] public int currentTurn;
    [HideInInspector] public int score;
    [SerializeField] private Camera playersCamera;
    [SerializeField] public Transform barTransform;
    [SerializeField] private TextMeshProUGUI turnText;

    // From spawner
    [SerializeField] private float playerCameraPosOffset = -5.0f;

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
        turnText.text = $"Turn : {currentTurn + 1}P";

        players[currentTurn].BeginMyTurn();
    }

    private void TurnEnd()
    {
        players[currentTurn].EndMyTurn();

        AdjustCameraPosition(currentTurn);

        currentTurn++;
        currentTurn %= players.Count;

        TurnBegin();
    }

    private void AdjustCameraPosition(int turn)
    {
        float maxHeight = 0f;
        foreach (PlayerManager player in players)
        {
            if (player.maxHeight > maxHeight)
            {
                maxHeight = player.maxHeight;
            }
        }

        playersCamera.transform.position = new Vector3(
            playersCamera.transform.position.x,
            players[turn].spawner.transform.position.y + playerCameraPosOffset,
            playersCamera.transform.position.z
        );
    }
}