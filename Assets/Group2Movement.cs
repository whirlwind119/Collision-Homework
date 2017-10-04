using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group2Movement : MonoBehaviour {

    public float xSpeed;
    public float amplitude;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(transform.position.x + xSpeed * Time.deltaTime, -1 * Mathf.Sin(Time.time) * amplitude, transform.position.z);
    }
}
