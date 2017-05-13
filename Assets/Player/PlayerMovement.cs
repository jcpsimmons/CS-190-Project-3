using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5f;
    private Vector3 moveDirection;

    void Update()
    {
        float horizontal = speed * Input.GetAxis("Horizontal");
        float vertical = speed * Input.GetAxis("Vertical");

        moveDirection = (horizontal * this.transform.right) + (vertical * this.transform.forward);
    }

    void FixedUpdate()
    {
        this.transform.Translate(moveDirection * Time.deltaTime, Space.World);
    }
}
