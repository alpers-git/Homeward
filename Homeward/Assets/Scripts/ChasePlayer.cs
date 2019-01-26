using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour {

    public GameObject target;
    public float speed = 0.3f;
    Rigidbody rb;
    private Vector3 direction;

    public Animator animator;
    float xAmount;
    float yAmount;

    public float forceMultip = 3.0f;

    // Use this for initialization
    void Start ()
    {
        FindTarget();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        //FindTarget();
        if (rb == null)
            Debug.Log("PANIC!");

        Vector3 difference = target.transform.position - transform.position;
        direction.Normalize();
        direction = Matrix4x4.Rotate(Quaternion.Euler(new Vector3(-30, 0, 0))) * new Vector4(direction.x, direction.y, direction.z, 1);
        xAmount = difference.x;
        yAmount = difference.z;
        animator.SetFloat("X", xAmount, 0.1f, Time.deltaTime);
        animator.SetFloat("Y", yAmount, 0.1f, Time.deltaTime);

        //***********
        direction = (target.transform.position - gameObject.transform.position);
        direction.Normalize();
        direction = Matrix4x4.Rotate(Quaternion.Euler(new Vector3(-30,0,0))) * new Vector4(direction.x, direction.y, direction.z, 1);
        gameObject.transform.Translate(direction * speed);
        //rb.velocity = (direction * speed) + (target.GetComponent<Rigidbody>().velocity);
        //rb.MovePosition(direction * speed);
    }

    public void FindTarget()
    {
        Debug.Log("Finding Target");
        target = GameObject.FindGameObjectsWithTag("Player")[0];
        if (target==null)
        {
            Debug.Log("target not found");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<HealthManager>().TakeDamage(1);
            GetComponent<HealthManager>().TakeDamage(1);

            Vector3 forceDir = transform.position - other.transform.position;
            forceDir.Normalize();

            GetComponent<Transform>().position = GetComponent<Transform>().position + forceDir * forceMultip;

        }
    }

    //void FixedUpdate()
    //{
    //    direction = (target.position - gameObject.transform.position).normalized;
    //    gameObject.GetComponent<Rigidbody2D>().MovePosition(direction * speed);
    //    //rb.MovePosition(direction * speed);
    //}
}
