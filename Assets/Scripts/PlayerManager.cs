using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public int playerId;
    public TextMeshProUGUI scoreText;
    public int score = -1;
    public float maxHeight = 0f;
    [SerializeField] public Camera playerCamera;
    [SerializeField] private float playerCameraOffset = 2.5f;
    public FallingObjectSpawner spawner;
    public bool isMyTurn = false;
    public bool isMyObjFallen = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (isMyTurn)
        {
            UpDateScoreText();
            playerCamera.transform.position = new Vector3(playerCamera.transform.position.x, maxHeight + playerCameraOffset, playerCamera.transform.position.z);
        }

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

    public void UpDateScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void UpdateMaxHeight(float newHeight)
    {
        if (maxHeight < newHeight)
        {
            maxHeight = newHeight;
        }
    }
}
