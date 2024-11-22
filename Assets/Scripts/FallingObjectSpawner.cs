using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private List<FallingObject> fallingObjects;

	// From maxHight
	[SerializeField] private float spawnPointOffset = 10.0f;

	[SerializeField] private float movableWidth = 15.0f;
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float rotateSpeed = 5.0f;
    [SerializeField] private float followStrength = 0.1f;
	private FallingObject nextObj;
	private Rigidbody2D nextObjRb;

    private void Start()
	{
		
    }

	private void Update()
	{
		if (playerManager.isMyTurn)
		{
            // Vector3 mousePos = playerManager.playersCamera.ScreenToWorldPoint(Input.mousePosition);

            /*this.transform.position = Vector3.Lerp(
				this.transform.position,
                new Vector3(mousePos.x, playerManager.maxHeight + spawnPointOffset, this.transform.position.z), 
                followStrength
			);*/

            this.transform.position = new Vector3(
                this.transform.position.x,
                playerManager.maxHeight + spawnPointOffset,
                this.transform.position.z
            );

            float x = Input.GetAxis("Horizontal");
            this.transform.Translate(
                new Vector3(x,0f,0f) * moveSpeed * Time.deltaTime
            );

            Vector3 currentPos = this.transform.position;
            currentPos.x = Mathf.Clamp(currentPos.x, -movableWidth, movableWidth);
            this.transform.position = currentPos;

            if (nextObj != null)
			{
				nextObj.transform.Rotate(new Vector3(0f, 0f, Input.GetAxis("Vertical") * rotateSpeed));
			}

			if (Input.GetMouseButtonDown(0) && nextObj != null)
			{
                nextObj.GetComponent<Rigidbody2D>().isKinematic = false;
                nextObj.transform.SetParent(null);
                nextObj.tag = $"player-{playerManager.playerId}";
                nextObj = null;
            }
		}
	}

	public IEnumerator HandleObject(float delay)
	{
        yield return new WaitForSeconds(delay);

        FallingObject obj = fallingObjects[Random.Range(0, fallingObjects.Count)];
        nextObj = Instantiate(obj, this.transform.position, Quaternion.identity);
        nextObjRb = nextObj.GetComponent<Rigidbody2D>();
        nextObj.transform.SetParent(this.transform);
        nextObj.SetPlayerManager(this.playerManager);
    }
}

