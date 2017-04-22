﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour {

    public int dmg = 2;
    public bool attacking = false;
    public float time = 1.0f;

    IEnumerator Start()
    {
        yield return StartCoroutine(WaitAndPrint(time));
    }
    IEnumerator WaitAndPrint(float waitTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            attacking = true;
            Debug.Log("I can attack");
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag != this.tag)
        {
            if (attacking)
            {
                Debug.Log("I attacked");
                col.gameObject.GetComponent<UnitScript>().DecreaseHP(dmg);
                attacking = false;
            }
        }
    }
}
