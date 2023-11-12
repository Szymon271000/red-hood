using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float mouseSensitivity = 3f;
    [SerializeField] float jumpSpeed = 5;
    [SerializeField] float mass = 1f;
    [SerializeField] Transform cameraTransform;

    public float walkSpeed = 4f;
    public float sprintSpeed = 8f;
    private float realSpeed;
    CharacterController controller;
    Vector3 velocity;
    Vector2 look;
    public int numberOfKeys { get; set; }
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
        numberOfKeys = 0;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGravity();
        UpdateMovement();
        UpdateLook();
    }

    private void UpdateGravity()
    {
        var gravity = Physics.gravity * mass * Time.deltaTime;
        velocity.y = controller.isGrounded ? -1f : velocity.y + gravity.y;
    }

    private void UpdateMovement()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var input = new Vector3();
        input += transform.forward * y;
        input += transform.right * x;
        input = Vector3.ClampMagnitude(input, 1f);

        realSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y += jumpSpeed;
        }
        controller.Move((input * realSpeed + velocity) * Time.deltaTime);
    }

    private void UpdateLook()
    {
        look.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        look.y += Input.GetAxis("Mouse Y") * mouseSensitivity;

        look.y = Mathf.Clamp(look.y, -25f, 45f);

        cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, look.x, 0);
    }
}
