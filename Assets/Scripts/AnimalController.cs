using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimalController : MonoBehaviour
{
    private bool isReleased = false;
    private Rigidbody2D rb;
    public float moveSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        if (!isReleased)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = new Vector3(mousePosition.x, this.transform.position.y, 0f);

            this.transform.Rotate(0, 0, Input.GetAxis("Horizontal") * 100f * Time.deltaTime);

            if (Input.GetMouseButtonDown(0))
            {
                ReleaseAnimal();
            }
        }
    }

    private void ReleaseAnimal()
    {
        isReleased = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isReleased)
        {
            float height = this.transform.position.y;

            FindObjectOfType<GameManager>().AddScoreAndAdjustCamera(height);

            FindObjectOfType<AnimalSpawner>().currentAnimal = null;

            Destroy(this);
        }
    }

}
