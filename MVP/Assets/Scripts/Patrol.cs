using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;

    private bool followingPlayer = false;

    // Use this for initialization
    void Start() {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update() {
        if(!followingPlayer) {
            // when object is not following player, it is patroling
            transform.LookAt(moveSpots[randomSpot].transform, moveSpots[randomSpot].transform.up);
            transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }


    }

    // when the antibody or tCell sees the player, it follows him
    private void OnTriggerEnter(Collider collision) {
        if (collision.CompareTag("Virus")) {
            followingPlayer = true;
        }
    }
}
