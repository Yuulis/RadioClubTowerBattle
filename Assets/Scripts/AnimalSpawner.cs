using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject currentAnimal;
    [SerializeField] private GameObject gameManagerObj;

    private GameManager gameManager;

    void Start()
    {
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    void Update()
    {
        if (currentAnimal == null)
        {
            SpawnAnimal();
        }
    }

    private void SpawnAnimal()
    {
        int randomIndex = Random.Range(0, animalPrefabs.Length);
        currentAnimal = Instantiate(animalPrefabs[randomIndex], gameManager.spawnPoint, Quaternion.identity);
    }
}

