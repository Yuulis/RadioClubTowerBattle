using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;
    public Text scoreText;
    [HideInInspector] public Vector2 spawnPoint = new(0f, 10f);
    private float highestPoint = 0f;
    private float maxHeightReached = 0f;

    public float cameraOffset = 10f;
    public float spawnOffset = 5f;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        UpdateScoreText();
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
        spawnOffset = Random.Range(3f,5f);
        spawnPoint.y = maxHeightReached + spawnOffset;
    }
}
