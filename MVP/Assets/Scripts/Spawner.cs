using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject spawnObj;
    public float spawnTime;
    public float spawnDelay;
    public bool stopSpawning = false;
    public float maxObjects;

    private GameObject[] spawnObjCount;

    // Start is called before the first frame update
    void Start() {        
        InvokeRepeating("spawnObject", spawnTime, spawnDelay);
        transform.localScale = new Vector3(1+(maxObjects/15), 1 + (maxObjects / 15), 1 + (maxObjects / 15));
    }

    private void Update() {
        // add tag 
        spawnObjCount = GameObject.FindGameObjectsWithTag("Antibody");

        //print(spawnObjCount.Length);

        //if(spawnObjCount.Length >= maxObjects) {
        //    stopSpawning = true;
        //} else {
        //    stopSpawning = false;
        //}
    }

    public void spawnObject() {
        if(!stopSpawning) {
            transform.Rotate(0, Random.Range(-30.0f, 30.0f), 0);
            Instantiate(spawnObj, transform.position, transform.rotation);
        }
    }
}
