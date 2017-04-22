using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour {

    public static int numberOfUnits = 0;

    public bool selected = false;
    public float moveSpeed;
    public Vector2 destination;
    public double maxPositionAndDestinationOffset;
    public int unitID = 0; // this is ID of group of ants united by target (for example going to the same point on map)


    private bool active = false; // ant is moving OR just selected
    private Vector2 direction;


    // Update is called once per frame
    void Update ()
    {
        if(GetComponent<Renderer>().isVisible && Input.GetMouseButtonUp(0))
        {
            Vector2 camPosition = Camera.main.WorldToScreenPoint(transform.position);
            camPosition.y = CameraScript.InvertY(camPosition.y);
            selected = CameraScript.selection.Contains(camPosition);
        }

        if(selected)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }

        if(Input.GetMouseButtonUp(1) && selected) 
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            active = true;
        }

        ControlGameObjectMovement();
	}

    private void ControlGameObjectMovement()
    {
        if (active)
        {
            direction = (destination - (Vector2)(gameObject.transform.position)).normalized;

            if ((destination - (Vector2)(gameObject.transform.position)).magnitude < maxPositionAndDestinationOffset)
            active = false;
            

            if (active) gameObject.GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
            else gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

    }

}
