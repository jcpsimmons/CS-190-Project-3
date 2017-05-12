using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5f;
    //CharacterController characterController;
    private Vector3 moveDirection;
    void Awake()
    {
        //characterController = this.GetComponent<CharacterController>();
    }
    
    void Update()
    {
        float horizontal = speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float vertical = speed * Input.GetAxis("Vertical") * Time.deltaTime;

        moveDirection = new Vector3(horizontal, 0, vertical);
        moveDirection = transform.TransformDirection(moveDirection);

        //characterController.Move(moveDirection);
    }

    void FixedUpdate()
    {
        this.transform.Translate(moveDirection);
    }
}
