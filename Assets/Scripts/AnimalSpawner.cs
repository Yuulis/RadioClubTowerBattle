using UnityEngine;
using UnityEngine.UI;

public class AnimalSpawner : MonoBehaviour
{
    [HideInInspector] public bool canSpawn = true;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AnimalController[] spawnObjects;

    void Start()
    {
        
    }

    void Update()
    {
        if (gameManager.currentObjState == 2)
        {
            canSpawn = true;
        }

        if (canSpawn)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        canSpawn = false;

        int idx = Random.Range(0, spawnObjects.Length);
        AnimalController nextObj = Instantiate(spawnObjects[idx], gameManager.spawnPoint.position, Quaternion.identity);
        nextObj.SetGameManager(gameManager);

        gameManager.currentObjState = 0;
    }
}

