using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
    private void Start()
    {
        
    }

    void Update()
    {
        Transform myTransform = this.transform;
        myTransform.Rotate(0.2f, 0f, 0.1f);
    }
}
