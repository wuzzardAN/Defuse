using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    bool dragging = false;
    private Rigidbody rb;

    void Awake()
    {
      rb = GetComponent<Rigidbody>();
    }

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
        float x = Input.GetAxis ("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
        float y = Input.GetAxis ("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;

        rb.AddTorque(Vector3.down * x);
        rb.AddTorque(Vector3.right * y);
      }
    }

}
