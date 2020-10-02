using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject followTarget;
    private Vector3 targetPosition;
    public float moveSpeed;
    public float offset;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        targetPosition = new Vector3(followTarget.transform.position.x, transform.position.y, (followTarget.transform.position.z + offset));
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
