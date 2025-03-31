using UnityEngine;

public class GearRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 60f; // 回転速度（度/秒）
    [SerializeField] private bool clockwise = true;     // 時計回りかどうか

    void Update()
    {
        float direction = clockwise ? -1f : 1f;
        transform.Rotate(0f, 0f, direction * rotationSpeed * Time.deltaTime);
    }
}
