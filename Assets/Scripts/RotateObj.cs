using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10f;
    bool dragging = false;

    void OnMouseDrag() {
      dragging = true;
    }

    void Update() {
      if(Input.GetMouseButtonUp(0)) {
        dragging = false;
      }
    }

    void FixedUpdate() {
      if(dragging) {
        float x = Input.GetAxis ("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        float y = Input.GetAxis ("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.down, x);
        transform.RotateAround(Vector3.right, y);
      }
    }

}
