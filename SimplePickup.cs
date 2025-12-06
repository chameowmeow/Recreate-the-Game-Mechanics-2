using UnityEngine;

public class SimplePickup : MonoBehaviour
{
    public float pickupDistance = 3f;
    public float holdDistance = 2f;
    public float followSpeed = 10f;

    Camera cam;
    GameObject heldObject;
    Rigidbody heldRB;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (heldObject == null)
        {
            TryPickup();
        }
        else
        {
            HoldObject();
            DropCheck();
        }
    }

    void TryPickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, pickupDistance))
            {
                if (hit.collider.CompareTag("Pickup"))
                {
                    heldObject = hit.collider.gameObject;
                    heldRB = heldObject.GetComponent<Rigidbody>();

                    if (heldRB != null)
                        heldRB.isKinematic = true;
                }
            }
        }
    }

    void HoldObject()
    {
        Vector3 target = cam.transform.position + cam.transform.forward * holdDistance;
        heldObject.transform.position = Vector3.Lerp(heldObject.transform.position, target, followSpeed * Time.deltaTime);
    }

    void DropCheck()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            heldRB.isKinematic = false;
            heldObject = null;
            heldRB = null;
        }
    }
}
