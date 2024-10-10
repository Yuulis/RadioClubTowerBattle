using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;
    public Text scoreText;
    public Transform spawnPoint;
    private float highestPoint = 0f;
    private float maxHeightReached = 0f;

    public float cameraOffset = 10f;
    public float spawnOffset = 5f;
    public float minAllowedHeight = -5f;

    private bool isGameOver = false;
    public List<GameObject> animals = new List<GameObject>();
    public GameObject currentAnimal;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        UpdateScoreText();
    }

    public void AddAnimalToList(GameObject animal)
    {
        animals.Add(animal);
        currentAnimal = animal;
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

    void Update()
    {
        if (!isGameOver && IsGameOverConditionMet())
        {
            TriggerGameOver();
        }
    }

    bool IsGameOverConditionMet()
    {
        foreach (GameObject animal in animals)
        {
            if (animal != null && animal.transform.position.y < minAllowedHeight)
            {
                return true;
            }
        }
        return false;
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene("Scenes/GameOver");
    }


}
