using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public int resourcesValue;
    public bool isTaken;
    GameObject carrier = null;

    void Update()
    {
        if (carrier == null)
        {
            isTaken = false;
            return;
        }
        else isTaken = true;

        gameObject.transform.position = carrier.transform.position;

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        UnitScript unit = collider.gameObject.GetComponent<UnitScript>();

        bool isAnt = (unit != null);

        if (isAnt)
        {
            if(!unit.hasResource && !isTaken)
            {
                unit.AddResources(resourcesValue);
                unit.GetComponent<Animator>().SetTrigger("Take");
                unit.hasResource = true;
                unit.foodOnBack = this;
                isTaken = true;
                carrier = collider.gameObject;                
            }
        }

     }











}
