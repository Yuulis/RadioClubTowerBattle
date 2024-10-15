using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObjectType
{
    capacitor = 1,
    drone = 2,
    plate = 3,
    robot = 4,
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
            Debug.Log("Hit");
        }
    }
}
