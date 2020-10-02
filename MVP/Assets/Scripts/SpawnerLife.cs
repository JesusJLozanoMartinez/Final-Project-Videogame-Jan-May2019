using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLife : MonoBehaviour {
    
    public float life;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(life <= 0) {
            Destroy(gameObject);
        }
    }

    // when the virus hits spawner, the spawner looses life
    private void OnTriggerEnter(Collider collision) {
        if (collision.CompareTag("Virus")) {
            if(life > 0) {
                life -= 10;
                print(life);
            }
        }
    }
}
