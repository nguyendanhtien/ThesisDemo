using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControl : MonoBehaviour
{
    public float rotationSpeed = 1.5f;
    public Vector3 dragOrigin;
    public Player player;

    private void OnMouseDown()
    {
        dragOrigin = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 delta = Input.mousePosition - dragOrigin;
        float rotationX = -delta.y * rotationSpeed;
        float rotationY = delta.x * rotationSpeed;

        player.transform.eulerAngles += new Vector3(rotationX, rotationY, 0);
        dragOrigin = Input.mousePosition;
    }

}
