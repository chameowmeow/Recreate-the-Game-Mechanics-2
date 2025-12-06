using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Move relative to camera direction
        Vector3 move = transform.right * x + transform.forward * z;

        transform.position += move.normalized * speed * Time.deltaTime;
    }
}
