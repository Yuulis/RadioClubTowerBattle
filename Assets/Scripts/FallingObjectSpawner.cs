using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingObjectSpawner : MonoBehaviour
{
	[SerializeField] private List<FallingObject> fallingObjects;
	[SerializeField] float movableWidth = 15.0f;
	[SerializeField] float followStrength = 0.1f;

    void Start()
	{

	}

	void Update()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.x = Mathf.Clamp(mousePos.x, -movableWidth, movableWidth);
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(mousePos.x, this.transform.position.y, this.transform.position.z), followStrength);

        if (Input.GetKeyDown(KeyCode.Space))
		{
			SpawnObject();
		}
	}

	private void SpawnObject()
	{
		FallingObject obj = fallingObjects[Random.Range(0, fallingObjects.Count)];
        Instantiate(obj, transform.position, Quaternion.identity);
	}
}

