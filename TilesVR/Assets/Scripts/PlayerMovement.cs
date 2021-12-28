using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _mouseSensitivity = 50f;
    [SerializeField] private float _minCameraView = -45f, _maxCameraView = 45f;

    private CharacterController _charController;
    private Camera _camera;
    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _camera = Camera.main;

        if (_charController == null)
            Debug.Log("No character attached to player");

        if (_camera == null)
            Debug.Log("No camera attached to player");

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //get WASD input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //move player based on this input
        Vector3 movement = transform.forward * vertical + transform.right * horizontal;
        _charController.Move(movement * Time.deltaTime * _speed);


        //get mouse input
        float mousex = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        // rotate camera from the based on the y input from mouse
        xRotation -= mousey;
        // clamp camera rotation between 45 degrees and -45 degrees
        xRotation = Mathf.Clamp(xRotation, _minCameraView, _maxCameraView);
        _camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // rotate player based on the x input from mouse
        transform.Rotate(0, mousex * 3, 0);
    }
}
