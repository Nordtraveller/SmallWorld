using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public int resourcesValue;
    private bool isTaken;
    GameObject carrier = null;

    void Update()
    {
        if (carrier == null) return;

        gameObject.transform.position = carrier.transform.position;

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (isTaken) return;

        UnitScript unit = collider.gameObject.GetComponent<UnitScript>();

        bool isAnt = (unit != null);

        Debug.Log(isAnt);

        if (isAnt)
        {
            if(!unit.hasResource)
            {
                unit.AddResources(resourcesValue);
                unit.hasResource = true;
                unit.foodOnBack = this;
                isTaken = true;
                carrier = collider.gameObject;                
            }
        }

     }











}
