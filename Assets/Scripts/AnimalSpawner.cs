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
    private Rigidbody currentAnimalRb;

    void Start()
    {
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameManager.currentAnimal != null)
        {
            currentAnimalRb = gameManager.currentAnimal.GetComponent<Rigidbody>();

            if (currentAnimalRb != null && currentAnimalRb.velocity.magnitude < stopThreshold)
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


    }

}

