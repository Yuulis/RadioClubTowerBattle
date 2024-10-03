using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    [HideInInspector] public Vector2 spawnPoint = new(0.0f, 10.0f);
    private float highestPoint = 0f;
    private float maxHeightReached = 0f;

    private float cameraOffset = 10.0f;
    private float spawnOffset = 5.0f;

    private void Start()
    {
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

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + Mathf.RoundToInt(maxHeightReached);
    }

    private void AdjustCameraPosition()
    {
        Vector3 cameraPosition = new(Camera.main.transform.position.x, highestPoint + cameraOffset, Camera.main.transform.position.z);
        Camera.main.transform.position = Vector3.Lerp(
            Camera.main.transform.position,
            cameraPosition,
            Time.deltaTime * 2f
        );
    }

    private void AdjustSpawnPoint()
    {
        spawnOffset = Random.Range(3f, 5f);
        spawnPoint.y = maxHeightReached + spawnOffset;
    }
}
