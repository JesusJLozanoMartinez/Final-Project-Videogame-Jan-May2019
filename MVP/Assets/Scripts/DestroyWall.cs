using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyWall : MonoBehaviour {
    public Text Objective;
    public Text Instructions;
    int spawnersAlive;


    // Start is called before the first frame update
    void Start() {
        Objective.text = "Objective: Destroy the antibody spawner";
    }

    // Update is called once per frame
    void Update() {
        spawnersAlive = GameObject.FindGameObjectsWithTag("Spawner").Length;
        if(spawnersAlive <= 0) {
            SetText();
            Destroy(gameObject);
        }
    }
    void SetText(){
        Instructions.text = "";
        Objective.text = "Objective: Get to the lungs";
    }
}
