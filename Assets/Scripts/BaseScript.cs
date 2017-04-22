using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour {

    public int resources = 0;
    public int hitPoints = 100;

    public static Rect resGUI = new Rect(10, 10, 50, 50);

    void OnGUI()
    {
        GUI.Label(resGUI, resources.ToString());
    }

    // Update is called once per frame
    void Update () {
		
	}
}
