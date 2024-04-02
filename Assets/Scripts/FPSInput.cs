using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSInput : MonoBehaviour
{
    public float speed = 1f;
    public float gravity = -9.8f;
    private CharacterController _charController;
    // Start is called before the first frame update
    void Start()
    {
        _charController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        //transform local rotaion to global rotation
        movement = transform.TransformDirection(movement);
        movement.y = gravity;
        _charController.Move(movement);
    }
}
