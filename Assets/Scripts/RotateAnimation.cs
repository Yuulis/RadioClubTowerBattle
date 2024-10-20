using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateanimation : MonoBehaviour
{

    void Update()
    {
        Transform myTransform = this.transform;
        myTransform.Rotate(0.2f, 0, 0.1f);

    }
}
