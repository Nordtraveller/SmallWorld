using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndTrack : MonoBehaviour {

    private bool isTracking = false;
    private UnitScript unit = null;
    private GameObject enemyBase;
    private GameObject yourBase;
    private GameObject trackedObject = null;
    private bool shouldGoToOwnBase = false;
    private bool shouldGoToEnemyBase = false;


    void Start()
    {
        unit = gameObject.transform.parent.GetComponent<UnitScript>();
        BaseHealthManager[] bases = FindObjectsOfType<BaseHealthManager>();
        foreach (BaseHealthManager bS in bases)
        {
            if (bS.gameObject.tag == "Black") enemyBase = bS.gameObject;
            else if (bS.gameObject.tag == "Red") yourBase = bS.gameObject;
        }
        trackedObject = enemyBase;
    }

    void Update()
    {

        if (trackedObject == null) trackedObject = enemyBase;
        unit.GoToPoint(trackedObject.transform.position);
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (isYourBase(trackedObject) && unit.foodOnBack) return;
        if (isEnemy(trackedObject)) return;

        if (isEnemy(c.gameObject)) trackedObject = c.gameObject;
        else if (isFood(c.gameObject))
        {
            if (!unit.foodOnBack) trackedObject = c.gameObject;
            else trackedObject = yourBase;
        }
        else
        {
            trackedObject = enemyBase;
        }
        
    }

    private bool isEnemy(GameObject obj)
    {
        if (obj == null) return false;
        return obj.tag == "Black" && obj.GetComponent<UnitScript>() != null;
    }

    private bool isFood(GameObject obj)
    {
        if (obj == null) return false;
        return obj.GetComponent<FoodScript>() != null;
    }

    private bool isYourBase(GameObject obj)
    {
        if (obj == null) return false;
        return obj.gameObject.tag == "Red" && obj.GetComponent<BaseHealthManager>() != null;
    }

    private bool isEnemyBase(GameObject obj)
    {
        if (obj == null) return false;
        return obj.gameObject.tag == "Black" && obj.GetComponent<BaseHealthManager>()!=null;
    }

    private bool isBase(GameObject obj)
    {
        if (obj == null) return false;
        return obj.GetComponent<BaseHealthManager>() != null;
    }

}
