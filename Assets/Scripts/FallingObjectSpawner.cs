using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
	[SerializeField] private List<FallingObject> fallingObjects;
	[SerializeField] private float movableWidth = 15.0f;
	[SerializeField] private float followStrength = 0.1f;
	[SerializeField] private float coolTime = 1.0f;
	private FallingObject nextObj;

    private void Start()
	{
		StartCoroutine(HandleObject(coolTime));
    }

	private void Update()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.x = Mathf.Clamp(mousePos.x, -movableWidth, movableWidth);
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(mousePos.x, this.transform.position.y, this.transform.position.z), followStrength);

        if (Input.GetMouseButtonDown(0) && nextObj != null)
		{
			nextObj.GetComponent<Rigidbody2D>().isKinematic = false;
			nextObj.transform.SetParent(null);
            nextObj = null;

            StartCoroutine(HandleObject(coolTime));
        }
	}

	private IEnumerator HandleObject(float delay)
	{
        yield return new WaitForSeconds(delay);

        FallingObject obj = fallingObjects[Random.Range(0, fallingObjects.Count)];
        nextObj = Instantiate(obj, transform.position, Quaternion.identity);
		nextObj.transform.SetParent(this.transform);
    }
}

