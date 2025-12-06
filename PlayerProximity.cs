using UnityEngine;

public class PlayerProximity : MonoBehaviour
{
    public bool nearObject = false;
    public GameObject objectInRange;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            nearObject = true;
            objectInRange = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            nearObject = false;
            objectInRange = null;
        }
    }
}
