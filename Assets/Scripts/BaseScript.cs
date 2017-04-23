using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour {

    public int resources = 0;

    public static Rect resGUI = new Rect(10, 10, 50, 50);

    void OnGUI()
    {
       if(gameObject.tag == "Black") GUI.Label(resGUI, resources.ToString());
    }

    void OnTriggerEnter2D(Collider2D c)
    { 
        UnitScript unit = c.gameObject.GetComponent<UnitScript>();

        if (unit == null) return;
        bool hasResource = unit.hasResource;

        if ((c.gameObject.tag == gameObject.tag) && hasResource)
            AddResources(unit.TakeResources());
    }

    private void AddResources(int value)
    {
        resources += value;
    }
}
