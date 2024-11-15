using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
        public RectTransform picture;
        private int counter = 0;
        private float move = -0.004f;

    void Update()
    {
        picture.position += new Vector3(move, 0, 0);
        counter++;
        if(counter == 6800) 
        {
            counter = 0;
            move *= -1;
        }
    }
}
