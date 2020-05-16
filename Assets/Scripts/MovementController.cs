using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Movement Speed
    public float MoveSpeed;
    // Rotation Speed
    public float RotationSpeed;

    public bool InvertedControls = false;

    //Rigid Body Component
    public Rigidbody Rigidbody;

    //Head Object
    public Transform Head;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        UpdatePositions();
        UpdateRotation();
    }

    private void UpdatePositions()
    {
        //Look For Keypresses
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        //Get the current position of the object
        Vector3 position = transform.position;
        //Modify the position for how much horizontal movement there is.
        position += horizontal * transform.right * MoveSpeed * Time.deltaTime;
        //Modify the position for how much vertical movement there is.
        position += vertical * transform.forward * MoveSpeed * Time.deltaTime;
        //Reassign the postion to tranform.
        transform.position = position;
    }

    private void UpdateRotation()
    {
        //Check for x axis rotation.
        float mouseX = Input.GetAxis("Mouse X");

        //Get current rotation of the object as euler angles.
        Vector3 rotation = transform.rotation.eulerAngles;
        //Update the y rotation of the object.
        rotation.y += mouseX * RotationSpeed * Time.deltaTime;

        //Reassign the rotation.
        transform.rotation = Quaternion.Euler(rotation);

        //Check for y axis rotation
        float mouseY = Input.GetAxis("Mouse Y");
        //Get current head rotation.
        Vector3 headRotation = Head.rotation.eulerAngles;
        //Update the rotation.
        float rotationStep = mouseY * RotationSpeed * Time.deltaTime;
        //Check for inverted controls
        if(!InvertedControls)
        {
            //If the controls are inverted3
            rotationStep *= -1;
        }
        headRotation.x += rotationStep;
        //Reassign the rotation.
        Head.rotation = Quaternion.Euler(headRotation);
    }

}
