using UnityEngine;
using UnityEngine.UI;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject currentAnimal;
    [SerializeField] private GameObject gameManagerObj;
    private GameManager gameManager;
    private bool canSpawn = true;
    private float stopThreshold = 0.1f;
    private Rigidbody2D currentAnimalRb2D;

    void Start()
    {
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameManager.currentAnimal != null)
        {
            currentAnimalRb2D = gameManager.currentAnimal.GetComponent<Rigidbody2D>();

            if (currentAnimalRb2D != null && currentAnimalRb2D.velocity.magnitude < stopThreshold)
            {
                Destroy(gameManager.currentAnimal);
                gameManager.currentAnimal = null;
                canSpawn = true;
            }
        }

        if (canSpawn)
        {
            SpawnAnimal();
        }
    }

    private void SpawnAnimal()
    {
        int randomIndex = Random.Range(0, animalPrefabs.Length);
        GameObject newAnimal = Instantiate(animalPrefabs[randomIndex], gameManager.spawnPoint.position, Quaternion.identity);

        gameManager.AddAnimalToList(newAnimal);
        gameManager.currentAnimal = newAnimal;

        canSpawn = false;

       //  Invoke("EnableAnimalSpawn", 3f);
    }

    private void EnableAnimalSpawn()
    {
        canSpawn = true;
    }


}

