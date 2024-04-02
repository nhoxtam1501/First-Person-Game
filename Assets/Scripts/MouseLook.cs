using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2,
    }

    //default value rotation
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivity = 1.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb != null )
            rb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (axes == RotationAxes.MouseX)
        {
            //horizontal rotation code
            //transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);

            float delta = Input.GetAxis("Mouse X") * sensitivity;
            float rotationY = transform.eulerAngles.y + delta;

            float rotationX = transform.eulerAngles.x;
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

        }
        else if (axes == RotationAxes.MouseY)
        {
            //vertical rotation code
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);


            //this code keep the same y angle(no horizontal rotation)
            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);


            //need to set the Mouse Y in negative because mouse up is Y positive
            //but in real world mouse up is looking down

            //work the same way with above except code below rotationY
            // transform.Rotate(Mathf.Clamp((-Input.GetAxis("Mouse Y") * sensitivity), minimumVert, maximumVert), 0, 0);

        }
        else
        {
            //both rotation code
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivity;
            float rotationY = transform.eulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }


    }
}
