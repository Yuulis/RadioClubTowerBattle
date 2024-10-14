using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimalController : MonoBehaviour
{
    public float moveSpeed = 10f;
    private GameManager gameManager;
    private Rigidbody2D rb;
    private bool isReleased = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        gameManager.currentObjState = 0;
    }

    void Update()
    {
        if (!isReleased)
        {
            this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, this.transform.position.y, 0f);
            this.transform.Rotate(0, 0, Input.GetAxis("Horizontal") * 100f * Time.deltaTime);

            if (Input.GetMouseButtonDown(0))
            {
                ReleaseAnimal();
            }
        }
    }

    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    private void ReleaseAnimal()
    {
        isReleased = true;
        gameManager.currentObjState = 1;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bar" || collision.gameObject.tag == "GameoverLine")
        {
            gameManager.currentObjState = 2;
            float height = this.transform.position.y;
            gameManager.AddScoreAndAdjustCamera(height);
            gameManager.currentObjOfController = null;
        }
    }

}
