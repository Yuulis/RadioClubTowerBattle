using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public int playerId;
    public GameManager gameManager;
    public Camera playersCamera;
    [HideInInspector] public FallingObjectSpawner spawner;
    [HideInInspector] public int score;
    [HideInInspector] public float maxHeight;
    [HideInInspector] public bool isMyTurn;
    [HideInInspector] public bool isMyObjFallen;

    private void Start()
    {
        spawner = GetComponentInChildren<FallingObjectSpawner>();

        isMyTurn = false;
        isMyObjFallen = false;
        maxHeight = 0f;
        score = 0;
    }

    private void Update()
    {
        
    }

    public void BeginMyTurn()
    {
        isMyTurn = true;
        isMyObjFallen = false;

        StartCoroutine(spawner.HandleObject(0.05f));
    }

    public void EndMyTurn()
    {
        isMyTurn = false;
    }

    public void UpdateMaxHeight(float newHeight)
    {
        if (maxHeight < newHeight)
        {
            maxHeight = newHeight;
        }
    }
}
