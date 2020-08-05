using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 7.0f;
    public float LookSpeed = 90.0f;
    public float JumpForce = 5.0f;
    private Camera cam = null;
    private Rigidbody rb = null;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.angularDrag = 10.0f; //dampen spin when hit
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

        cam = this.transform.GetComponentInChildren<Camera>();
        cam.transform.position = this.transform.position;
        cam.transform.rotation = this.transform.rotation;

        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        this.transform.Translate(Vector3.right * horz * MoveSpeed * Time.deltaTime);
        this.transform.Translate(Vector3.forward * vert * MoveSpeed * Time.deltaTime);

        float mousex = Input.GetAxis("Mouse X");
        float mousey = Input.GetAxis("Mouse Y");
        this.transform.localRotation *= Quaternion.AngleAxis(mousex * LookSpeed * Time.deltaTime, Vector3.up);
        cam.transform.localRotation *= Quaternion.AngleAxis(mousey * LookSpeed * Time.deltaTime, Vector3.left);

        if(Input.GetButtonDown("Jump") == true)
        {
            rb.AddRelativeForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
}
