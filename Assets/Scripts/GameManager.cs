using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Collections;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;
    public Text scoreText;
    public Transform spawnPoint;
    public float cameraOffset = 10f;
    public float spawnOffset = 5f;
    public float minAllowedHeight = -5f;

    /*
     * currentObjState
     * -1: No object is spawned                      -> spwanable
     * 0 : Object is spawned but not released
     * 1 : Object is released and falling
     * 2 : Object has landed or touched GameOverLine -> spawnable    
     */
    public int currentObjState;

    public AnimalController currentObjOfController;
    [HideInInspector] public bool isGameOver = false;
    private float highestPoint = 0f;
    private float maxHeightReached = 0f;

    void Start()
    {
        currentObjState = -1;
        currentObjOfController = null;

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        UpdateScoreText();
    }

    void FixedUpdate()
    {
        if (currentObjOfController == null)
        {
            
        }
    }

    public void AddScoreAndAdjustCamera(float height)
    {
        if (height > highestPoint)
        {
            highestPoint = height;
            AdjustCameraPosition();
        }


        if (height > maxHeightReached)
        {
            maxHeightReached = height;
            UpdateScoreText();
            AdjustSpawnPoint();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + Mathf.RoundToInt(maxHeightReached);
    }

    void AdjustCameraPosition()
    {
        Vector3 targetPosition = new Vector3(
            mainCamera.transform.position.x,
            highestPoint + cameraOffset,
            mainCamera.transform.position.z
        );

        mainCamera.transform.position = Vector3.Lerp(
            mainCamera.transform.position,
            targetPosition,
            Time.deltaTime * 2f
        );
    }

    void AdjustSpawnPoint()
    {
        spawnOffset = Random.Range(3f, 5f);

        Vector3 newSpawnPosition = new Vector3(
            spawnPoint.position.x,
            maxHeightReached + spawnOffset,
            spawnPoint.position.z
        );

        spawnPoint.position = newSpawnPosition;
    }

    private IEnumerator DelayCoroutine(int delayFrame, Action action)
    {
        for (int i = 0; i < delayFrame; i++)
        {
            yield return null;
        }

        action?.Invoke();
    }
}