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
            transform.position = new Vector3(mousePosition.x, transform.position.y, 0);

            if (Input.GetMouseButtonDown(0))
            {
                ReleaseAnimal();
            }
        }
    }

    void ReleaseAnimal()
    {
        isReleased = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isReleased)
        {
            float height = transform.position.y;

            FindObjectOfType<GameManager>().AddScoreAndAdjustCamera(height);

            FindObjectOfType<AnimalSpawner>().currentAnimal = null;

            Destroy(this);
        }
    }

}
