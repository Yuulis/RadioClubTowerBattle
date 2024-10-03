using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject currentAnimal;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        
    }

    private void Update()
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

