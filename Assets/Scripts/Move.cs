using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private CharacterController _controller;
    private Transform _camera;
    private Vector3 movement;
    public int speed = 5;
    public float xRotation = 2f;
    public float yRotation = 1f;
    public float valueForCamera = 0f;
    // Start is called before the first frame update
    void Start()
    {

        _camera = GameObject.Find("Camera").GetComponent<Transform>();
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // rotate on y axis to look around
        transform.Rotate(0, xRotation * Input.GetAxis("Mouse X"), 0);
        // set movement 
        movement = new Vector3(speed * Input.GetAxis("Horizontal"), 0, speed * Input.GetAxis("Vertical"));
        // move accoridng to local rotation
        _controller.Move(transform.TransformDirection(movement * Time.deltaTime));

        //rotate on x axis to look around

        valueForCamera += yRotation * -Input.GetAxis("Mouse Y");
        _camera.rotation = Quaternion.Euler(Mathf.Clamp(valueForCamera, -90, 90), _camera.eulerAngles.y, _camera.eulerAngles.z);

        //_camera.eulerAngles = new Vector3()
        //_camera.transform.Rotate(yRotation * -Input.GetAxis("Mouse Y"), 0, 0);
        //if (_camera.transform.eulerAngles.x >= 270)
        //{
        //    _camera.transform.eulerAngles = new Vector3(Mathf.Clamp(_camera.transform.eulerAngles.x, 270), 0, 0);
        //}
        //else
        //{
        //    _camera.transform.eulerAngles = new Vector3(Mathf.Clamp(_camera.transform.eulerAngles.x, 0, 89f), 0, 0);
    }

}
