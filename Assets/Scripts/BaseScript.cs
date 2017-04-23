using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour {

    public int resources = 0;
    public int hitPoints = 100;

    public static Rect resGUI = new Rect(10, 10, 50, 50); // hehe, nie uzywam ]:->

    void OnGUI()
    {
       if(gameObject.tag == "Black") GUI.Label(new Rect(10, 10, 100, 50), "Zasoby: " + resources.ToString());
       else GUI.Label(new Rect(900, 10, 100, 50), "Zasoby: " + resources.ToString());
        if (gameObject.tag == "Black") GUI.Label(new Rect(110, 10, 100, 50), "HP: " + hitPoints.ToString());
        else GUI.Label(new Rect(1000, 10, 100, 50), "HP: " + hitPoints.ToString());
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


    public void TakeDamage(int strength)
    {
        hitPoints -= strength;
        if (hitPoints <= 0) Destroy(gameObject.transform.parent.gameObject);
    }
}
