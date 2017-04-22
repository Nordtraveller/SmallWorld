using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour {

    public bool selected = false;

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
   
	}

   
}
