using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    // ������Prefab���i�[���邽�߂̕ϐ�
    public GameObject[] animalPrefabs;
    // ���݂̓������i�[����ϐ�
    public GameObject currentAnimal;
    // �����𐶐�����ʒu
    public Transform spawnPoint;

    void Update()
    {
        // ���ݓ��������݂��Ȃ��ꍇ�A�V���������𐶐�
        if (currentAnimal == null)
        {
            SpawnAnimal();
        }
    }

    // �V���������𐶐����郁�\�b�h
    void SpawnAnimal()
    {
        // �����_���ɓ�����I��
        int randomIndex = Random.Range(0, animalPrefabs.Length);

        // �I�����������𐶐����� currentAnimal �ɕۑ�
        currentAnimal = Instantiate(animalPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
    }
}

