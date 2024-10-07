using UnityEngine;
using UnityEngine.UI;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject currentAnimal;
    [SerializeField] private GameObject gameManagerObj;
    private GameManager gameManager;
    private bool canSpawn = true;

    void Start()
    {
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    void Update()
    {
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

        Invoke("EnableAnimalSpawn", 2f);
    }

    private void EnableAnimalSpawn()
    {
        canSpawn = true;
    }
}

