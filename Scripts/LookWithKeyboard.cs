#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWithKeyboard : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    InputAction movement;
    //InputAction escape;


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;

        movement = new InputAction("PlayerMovement", binding: "<Gamepad>/rightStick");
        movement.AddCompositeBinding("Dpad")
            .With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/rightArrow");
        //escape = new InputAction("Pause", binding: "<Keyboard>/escape");

        //escape.Enable();

        movement.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Cursor.lockState == CursorLockMode.Locked && escape.triggered)
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //}

        //else if (Cursor.lockState == CursorLockMode.None && escape.triggered)
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //}

#if ENABLE_INPUT_SYSTEM
        float mouseX = 0, mouseY = 0;

        if (Keyboard.current != null)
        {
            var delta = movement.ReadValue<Vector2>(); ;
            mouseX += delta.x;
            mouseY += delta.y;
        }
        if (Gamepad.current != null)
        {
            var value = Gamepad.current.rightStick.ReadValue() * 2;
            mouseX += value.x;
            mouseY += value.y;
        }

        mouseX *= mouseSensitivity * Time.deltaTime;
        mouseY *= mouseSensitivity * Time.deltaTime;
#else
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
#endif

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.left * mouseY);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}