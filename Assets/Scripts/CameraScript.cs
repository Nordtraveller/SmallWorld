using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Texture2D selectionTexture = null;
    public static Rect selection = new Rect(0, 0, 0, 0);
    private Vector2 startClick = -Vector2.one;
	
	// Update is called once per frame
	void Update ()
    {
        CheckCamera();
	}

    private void CheckCamera()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startClick = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startClick = -Vector2.one;
        }

        if(Input.GetMouseButton(0))
        {
            selection = new Rect(startClick.x, InvertY(startClick.y), 
                Input.mousePosition.x - startClick.x, InvertY(Input.mousePosition.y) - InvertY(startClick.y));
        }

        if (selection.width < 0)
        {
            selection.x += selection.width;
            selection.width = -selection.width;
        }
        if (selection.height < 0)
        {
            selection.y += selection.height;
            selection.height = -selection.height;
        }
    }

    private void OnGUI()
    {
        if(startClick != - Vector2.one)
        {
            GUI.color = new Color(1, 1, 1, 0.5f );
            GUI.DrawTexture(selection, selectionTexture);
        }
    }

    public static float InvertY(float y)
    {
        return Screen.height - y;
    }
}
