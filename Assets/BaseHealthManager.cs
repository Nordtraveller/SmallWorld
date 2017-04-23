using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthManager : MonoBehaviour {

    private BaseScript myBase;
    public float timeBetweenHits = 0.8f;
    private float timer;
    
    void Start()
    {
        myBase = gameObject.GetComponentInChildren<BaseScript>();
        timer = timeBetweenHits;
    }

	void OnCollisionStay2D(Collision2D col)
    {
        timer -= Time.deltaTime;
        if (timer >= 0) return;

        if (isEnemyAndAnt(col.gameObject))
        {
            myBase.TakeDamage(col.gameObject.GetComponent<HeadScript>().dmg);
        }

        timer = timeBetweenHits;
        
    }

    private bool isEnemyAndAnt(GameObject obj)
    {
      if(obj == null) return false;
        UnitScript unit = null;
        try { unit = obj.GetComponent<UnitScript>(); } catch (System.NullReferenceException) { };
        if (unit == null) return false;

        if (obj.tag != gameObject.tag) return true;

        return false;
    }

}
