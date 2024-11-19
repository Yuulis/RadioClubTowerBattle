using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomMove : MonoBehaviour
{

    public Vector3 targetPosition;

    private void Start() 
    {
    
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            MoveCamera();
        }
    }
    
    
    // Update is called once per frame
   public void MoveCamera()
    {
       transform.position = targetPosition;
    }
}
