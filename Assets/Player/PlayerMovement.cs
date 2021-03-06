﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public BeaconController beaconController;
    public Image shaderTimerImage;

    public float speed = 5f;
    private Vector3 moveDirection;

    public float footstepInterval = .5f;
    private float footstepCountdown = 0f;
    private float shaderTimer = 0.0f;
    public float shaderTimerReset = 5.0f;
    public int limit = 5;
    private Shader standardShader;
    private Shader transparentShader;
    private Color standardColor;
    private Color transparentColor;
    private bool wallsTransformed = false;

    void Start()
    {
        standardShader = Shader.Find("Standard");
        transparentShader = Shader.Find("Transparent/Diffuse");
        standardColor = GameObject.Find("LeftWall").GetComponent<MeshRenderer>().material.color;
        transparentColor = new Color(0.0f, 0.0f, 0.0f, 0.1f); // Edit the last value here to change how transparent the walls become.
    }

    void Update()
    {
        float horizontal = speed*Input.GetAxis("Horizontal");
        float vertical = speed*Input.GetAxis("Vertical");

        moveDirection = (horizontal*this.transform.right) + (vertical*this.transform.forward);

        footstepCountdown -= Time.deltaTime;
        if (moveDirection != Vector3.zero && footstepCountdown <= 0f)
        {
            AkSoundEngine.PostEvent("Footstep_Randomizer", this.gameObject);
            footstepCountdown = footstepInterval;
        }

        if (Input.GetKeyDown(KeyCode.X) && limit > 0 && shaderTimer <= 0.0f)
        {
            TransformWalls();
            wallsTransformed = true;
            limit--;
            shaderTimer = shaderTimerReset;
            shaderTimerImage.gameObject.SetActive(true);
        }

        if (shaderTimer <= 0.0f && wallsTransformed)
        {
            RevertWalls();
            wallsTransformed = false;
            shaderTimerImage.gameObject.SetActive(false);
        }

        if (shaderTimer > 0.0f)
        {
            shaderTimer -= Time.deltaTime;
            shaderTimerImage.fillAmount = shaderTimer / shaderTimerReset;
        }
    }

    void FixedUpdate()
    {
        this.transform.Translate(moveDirection*Time.deltaTime, Space.World);
    }

    private void TransformWalls()
    {
        beaconController.ToggleFireworks(true);
        foreach (var gameObj in FindObjectsOfType(typeof (GameObject)) as GameObject[])
        {
            if (gameObj.name.Contains("Wall") && gameObj.activeSelf)
            {
                gameObj.GetComponent<MeshRenderer>().material.shader = transparentShader;
                gameObj.GetComponent<MeshRenderer>().material.color = transparentColor;
            }
        }
    }

    private void RevertWalls()
    {
        beaconController.ToggleFireworks(false);
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name.Contains("Wall") && gameObj.activeSelf)
            {
                gameObj.GetComponent<MeshRenderer>().material.shader = standardShader;
                gameObj.GetComponent<MeshRenderer>().material.color = standardColor;
            }
        }
    }
}