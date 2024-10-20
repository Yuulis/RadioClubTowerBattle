using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = -1;
    public float maxHeight = 0f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float playerCameraOffset = 2.5f;

    private void Start()
    {
        
    }

    private void Update()
    {
        UpDateScoreText();

        playerCamera.transform.position = new Vector3(playerCamera.transform.position.x, maxHeight + playerCameraOffset, playerCamera.transform.position.z);
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
