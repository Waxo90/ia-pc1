using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;
    Vector3 desired = Vector3.zero;
    Vector3 steer = Vector3.zero;

    float maxSpeed = 5;
    float maxSteer = 5;

    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Target").transform;
                
        desired = -(target.position - transform.position).normalized * maxSpeed;
        steer = Vector3.ClampMagnitude(desired - velocity, maxSteer);

        velocity += steer * Time.deltaTime;
        transform.position += velocity * Time.deltaTime; 

        if (transform.position.x <= 0.3 & transform.position.x >= -0.3)
        {
            Debug.Log("Ganaste");
            Destroy(gameObject);
        }else if (transform.position.y <= 0.3 & transform.position.y >= -0.3) 
        {
            Debug.Log("Ganaste");
            Destroy(gameObject);
        }

        
    }

    void OnBecameInvisible() {
            Destroy(gameObject);
            Debug.Log("Perdiste");
        }
}
