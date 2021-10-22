﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBehaviour : MonoBehaviour
{
    public float cursorSpeed = 10.0f;

    private KeyCode AButton = KeyCode.JoystickButton2;
    //private KeyCode BButton = KeyCode.JoystickButton1;
    //private KeyCode XButton = KeyCode.JoystickButton3;
    //private KeyCode YButton = KeyCode.JoystickButton0;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float rawInputX = Input.GetAxis("Horizontal");
        float rawInputY = Input.GetAxis("Vertical");

        float translateX = (rawInputX * Time.deltaTime) * cursorSpeed;
        float translateY = (rawInputY * Time.deltaTime) * cursorSpeed * -1;

        transform.Translate(translateX,0,translateY);

    }

    private void OnTriggerEnter(Collider other)
    {

        GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(AButton))
        {
            other.GetComponentInParent<HouseStateController>().repair();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);
    }
}
