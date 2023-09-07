using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragRotation : MonoBehaviour, IDragHandler
{
    public Transform objectToRotate;
    public Rigidbody m_rb;
    public float rotationSpeed = 1.5f;

    private Vector3 dragOrigin;

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 delta = eventData.delta;
        // Debug.Log(delta);
        float rotationY = delta.x * rotationSpeed;
        float rotationX = delta.y * rotationSpeed;

        objectToRotate.Rotate(Vector3.up, rotationY, Space.World);
        objectToRotate.Rotate(Vector3.right, rotationX, Space.World );
        objectToRotate.rotation = Quaternion.Euler(objectToRotate.rotation.eulerAngles.x,
            objectToRotate.rotation.eulerAngles.y, 0);
        // objectToRotate.transform.eulerAngles = new Vector3(objectToRotate.transform.eulerAngles.x
        //     , objectToRotate.transform.eulerAngles.y, 0);
        // m_rb.velocity = Vector3.zero;
    }
}