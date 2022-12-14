using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera playerCamera;
    public CharacterController characterController;
    public Transform playerBody;
    public float mouseSens = 100;
    public float rotationX = 0f;
    public float movementSpeed = 10f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerBody = GetComponent<Transform>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    // Update is called once per frame
    void Update()
    {
        CharacterView();
        CharacterMove();
    }

    private void CharacterView()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void CharacterMove()
    {
        float x = Input.GetAxis("Horizontal"); //gibt den Wert -1, 0 oder 1 wieder
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;
        characterController.Move(movement * Time.deltaTime * movementSpeed);
    }

}
