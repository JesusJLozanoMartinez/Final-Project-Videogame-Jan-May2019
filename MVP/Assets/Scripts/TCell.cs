using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCell : MonoBehaviour {
    
    private float deathTimer = 10.0f;
    private bool touchedVirus = false;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        
    }

    // when tcell touches virus
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Virus") && !touchedVirus) {
            Virus.speed = Virus.speed * 0.8f;
            touchedVirus = true;
            print(Virus.speed);
            gameObject.transform.parent = collision.transform;
            Destroy(gameObject, deathTimer);
        }
    }

}
