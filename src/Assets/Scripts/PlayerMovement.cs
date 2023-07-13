using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMOvement : MonoBehaviour
{
    public float moveSpeed;
    public Transform orientation;
    float horizontalInput, verticalInput;
    Vector3 moveDirection;
    Rigidbody theRB;
    public KeyCode runKey, slowWalkKey;

    void Start()
    {
        theRB = GetComponent<Rigidbody>();   
        theRB.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        InputAxis();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void InputAxis()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        theRB.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        float currentSpeed = moveSpeed;
        Vector3 flat = new Vector3(theRB.velocity.x, 0f, theRB.velocity.z);
        if (Input.GetKey(runKey))
            currentSpeed *= 2;
        else if (Input.GetKey(slowWalkKey))
            currentSpeed /= 2;
        if (flat.magnitude > currentSpeed)
        {
            Vector3 limited  = flat.normalized * currentSpeed;
            theRB.velocity = new Vector3(limited.x, theRB.velocity.y, limited.z);
        }
    }
}
