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

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bar" || collision.gameObject.tag == "GameoverLine")
        {
            // Debug.Log("Hit");
        }
    }
}
