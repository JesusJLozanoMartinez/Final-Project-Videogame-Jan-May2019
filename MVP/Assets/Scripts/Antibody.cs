using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antibody : MonoBehaviour {

    public float deathTimer = 15.0f;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        Destroy(gameObject, deathTimer);
    }
}
