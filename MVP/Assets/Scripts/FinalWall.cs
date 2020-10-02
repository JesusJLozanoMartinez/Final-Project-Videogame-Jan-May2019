using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalWall : MonoBehaviour
{
    bool activated = false;
    public Transform wallPosition;
    float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if(activated) {
            transform.position = Vector3.MoveTowards(transform.position, wallPosition.position, speed * Time.deltaTime);
        }
    }

    // when the antibody or tCell sees the player, it follows him
    private void OnTriggerExit(Collider collision) {
        if (collision.CompareTag("Virus")) {
            activated = true;
        }
    }
}
