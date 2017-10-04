using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : MonoBehaviour {

    public float speed;
    public float angularThreshhold;
    public float distanceThreshhold = 2;
    public GameObject target;
    public GameObject other1;

    private float timer = 0f;
    private bool isEvading = false;
    private Vector3 direction;
    private float dot;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        direction = Vector3.Normalize(target.transform.position - transform.position);
        dot = Vector3.Dot(Vector3.right, direction);

        float distance = Vector2.Distance(transform.position, other1.transform.position);
        if (isEvading) {
            timer += Time.deltaTime;
        }
        if (timer > 1 && isEvading) {
            isEvading = false;
        }
        if (dot > 0.707 && (target.transform.position - transform.position).magnitude < 2){
            Debug.Log("asdf");
            evade(distance);    
        }
        if (!isEvading) {
            pursue();
            timer = 0f;
        }

        transform.Translate(Vector3.right * Time.deltaTime * speed);
        

    }


    private void pursue() {
        //calculate the angle
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 3f);

        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void evade(float distance) {
        isEvading = true;
        float angle = Mathf.LerpAngle(transform.eulerAngles.z, transform.eulerAngles.z - 40, 1/distance);
        transform.eulerAngles = new Vector3(0, 0, angle);

    }
}
