using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomObjectSpawner : MonoBehaviour
{
    // area is areaWidth x areaHeight rectangle. GameObject is right in the middle of thic rect.
    public float areaWidth;
    public float areaHeight;
    public List<GameObject> prefabsToSpawn;
    public float spawnInterval; // For now It'll be constant interval, but it should be quite easy to set interval up to random value from some range.

    private Vector3 nextSpawnPoint;
    private float timeCounter = 0;

    void Start ()
    {
        bool nullInPrefabs = false;

        foreach (GameObject p in prefabsToSpawn)
            if (p == null) nullInPrefabs = true;
        
        if (prefabsToSpawn.Count == 0 || nullInPrefabs) throw new System.Exception("You must assign prefabsToSpawn to RandomObjectSpawner script.");
	}
	
	void Update ()
    {
        timeCounter -= Time.deltaTime;

        if (timeCounter > 0) return;

        int objectIndex = Random.Range(0, prefabsToSpawn.Count);

        nextSpawnPoint = getRandomPoint();

        Instantiate(prefabsToSpawn[objectIndex], nextSpawnPoint, new Quaternion(0,0,0.707f,0.707f));

        timeCounter = spawnInterval;
	}

    private Vector3 getRandomPoint()
    {
        float randomX, randomY;

        randomX = Random.Range(gameObject.transform.position.x - (areaWidth / 2.0f), gameObject.transform.position.x + (areaWidth / 2.0f));
        randomY = Random.Range(gameObject.transform.position.y - (areaHeight / 2.0f), gameObject.transform.position.y + (areaHeight / 2.0f));

        return new Vector3(randomX, randomY, gameObject.transform.position.z);
    }


}
