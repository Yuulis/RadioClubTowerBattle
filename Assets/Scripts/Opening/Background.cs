using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1.0f;
    private Vector3 cameraRectMin;

    void Start()
    {
        cameraRectMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
    }

    
    void Update()
    {
        this.transform.Translate(scrollSpeed * Time.deltaTime * Vector3.left);
        if (this.transform.position.x < (cameraRectMin.x - Camera.main.transform.position.x) * 2)
        {
            this.transform.position = new Vector3(
                (Camera.main.transform.position.x - cameraRectMin.x) * 2,
                this.transform.position.y,
                this.transform.position.z
                );
        }
    }
}
