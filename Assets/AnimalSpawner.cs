using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject currentAnimal;
    public Transform spawnPoint;

    void Update()
    {
        if (currentAnimal == null)
        {
            SpawnAnimal();
        }
    }

    void SpawnAnimal()
    {
        int randomIndex = Random.Range(0, animalPrefabs.Length);
        currentAnimal = Instantiate(animalPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
    }
}

