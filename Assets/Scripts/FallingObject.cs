using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObjectType
{
    battery = 1,
    board_1 = 2,
    board_2 = 3,
    capacitor = 4,
    drone_1 = 5,
    drone_2 = 6,
    iron_1 = 7,
    iron_2 = 8,
    iron_3 = 9,
    plate = 10,
    robot = 11,
    screw = 12
}


public class FallingObject : MonoBehaviour
{
    public ObjectType objectType;
    private PlayerManager playerManager;
    private Rigidbody2D rb;
    private bool touched = false;
    private bool failed = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!failed)
        {
            if (touched && rb.IsSleeping())
            {
                playerManager.isMyObjFallen = true;
                failed = true;
                playerManager.gameManager.score++;
                playerManager.UpdateMaxHeight(this.transform.position.y);
            }
        }
    }

    public void SetPlayerManager(PlayerManager playerManager)
    {
        this.playerManager = playerManager;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Bar") || collision.gameObject.CompareTag("player-1") || collision.gameObject.CompareTag("player-2")) && !touched)
        {
            touched = true;
        }
    }
}
