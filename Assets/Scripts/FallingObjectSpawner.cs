using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private List<FallingObject> fallingObjects;
	[SerializeField] private float spawnPointOffset = 10.0f;
	[SerializeField] private float movableWidth = 15.0f;
    [SerializeField] private float rotateSpeed = 10.0f;
    [SerializeField] private float followStrength = 0.1f;
	[SerializeField] private float coolTime = 1.0f;
	private FallingObject nextObj;

    private void Start()
	{
		// StartCoroutine(HandleObject(0.05f));
    }

	private void Update()
	{
		if (playerManager.isMyTurn)
		{
			Vector3 mousePos = playerManager.playerCamera.ScreenToWorldPoint(Input.mousePosition);
			float viewPos_x = playerManager.playerCamera.WorldToViewportPoint(mousePos).x;
			Debug.Log(viewPos_x);

            if (0 <= viewPos_x && viewPos_x <= 1.0)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(mousePos.x, playerManager.maxHeight + spawnPointOffset, this.transform.position.z), followStrength);
            }
            mousePos.x = Mathf.Clamp(mousePos.x, -movableWidth, movableWidth);

			if (nextObj != null)
			{
				nextObj.transform.Rotate(new Vector3(0f, 0f, Input.GetAxis("Horizontal") * rotateSpeed));
			}

			if (Input.GetMouseButtonDown(0) && nextObj != null)
			{
				nextObj.GetComponent<Rigidbody2D>().isKinematic = false;
				nextObj.transform.SetParent(null);
				nextObj = null;

				// StartCoroutine(HandleObject(coolTime));
				// gameManager.currentTurn++;
            }
		}
	}

	public IEnumerator HandleObject(float delay)
	{
        yield return new WaitForSeconds(delay);

        FallingObject obj = fallingObjects[Random.Range(0, fallingObjects.Count)];
        nextObj = Instantiate(obj, this.transform.position, Quaternion.identity);
		nextObj.transform.SetParent(this.transform);
        nextObj.SetPlayerManager(this.playerManager);
    }
}

