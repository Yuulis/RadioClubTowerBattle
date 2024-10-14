using UnityEngine;
using UnityEngine.UI;

public class FallingObjectSpawner : MonoBehaviour
{
	[SerializeField] private FallingObject fallingObject;

	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SpawnObject();
		}
	}

	private void SpawnObject()
	{
		Instantiate(fallingObject, transform.position, Quaternion.identity);
	}
}

