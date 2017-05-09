using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
    public int health = 100;

    //void OnControllerColliderHit(ControllerColliderHit other)
    //{
    //    if (other.collider.CompareTag("Enemy"))
    //    {
    //        health -= 5;
    //        Debug.Log(health);
    //    }
    //}

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            health -= 5;
            Debug.Log(health);
        }
    }
}
