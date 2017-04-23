using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnNiewiem : RandomObjectSpawner {

    public int antCost = 20;	
	// Update is called once per frame
	void Update ()
    {
        timeCounter -= Time.deltaTime;

        BaseScript antBase = gameObject.GetComponent<BaseScript>();

        bool hasEnoughReources = antBase.resources >= antCost;

        bool wantsToSpawn = false;
        if (gameObject.tag == "Black")
            wantsToSpawn = Input.GetButtonDown("Jump");
        else if (gameObject.tag == "Red")
        {
            wantsToSpawn = timeCounter <= 0;
            if (wantsToSpawn) timeCounter = spawnInterval;
        }

        if (wantsToSpawn && hasEnoughReources)
        {
            int objectIndex = Random.Range(0, prefabsToSpawn.Count);
            nextSpawnPoint = getRandomPoint();
            GameObject obj = Instantiate(prefabsToSpawn[objectIndex], nextSpawnPoint, new Quaternion(0, 0, 0.707f, 0.707f));
            wantsToSpawn = false;
            antBase.resources -= antCost;
        }


    }
}
