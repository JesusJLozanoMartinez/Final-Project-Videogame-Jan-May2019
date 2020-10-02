using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    private GameObject playerVirus;

    public float moveSpeed;
    private float randomNumber;
    private float maxSpeed = 2.5f;

    private Vector3 targetPosition;
    private bool followingPlayer = false;

    void Start() {
        playerVirus = GameObject.FindGameObjectWithTag("Virus");

        // makes virus random size and speed
        randomNumber = Random.Range(1.0f, maxSpeed - 1.2f);
        moveSpeed = moveSpeed * randomNumber;
        //transform.localScale = new Vector3(maxSpeed - randomNumber, maxSpeed - randomNumber, maxSpeed - randomNumber);
    }

    // Update is called once per frame
    void Update() {
        // follows player
        if(followingPlayer) {

            // moves towards virus
            targetPosition = new Vector3(playerVirus.transform.position.x, transform.position.y, playerVirus.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, (moveSpeed) * Time.deltaTime);

            // is directed towards virus
            transform.LookAt(playerVirus.transform, playerVirus.transform.up);
        }
    }

    // when the antibody or tCell sees the player, it follows him
    private void OnTriggerEnter(Collider collision) {
        if(collision.CompareTag("Virus")) {
            followingPlayer = true;
            //print("touch");
        }
    }
}
