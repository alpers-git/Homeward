using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseandShootTarget : MonoBehaviour
{

    public GameObject target;
    public float minDistanceToTarget;
    public float speed = 0.3f;
    Rigidbody rb;
    private Vector3 direction;

    public Animator animator;
    float xAmount;
    float yAmount;
    public float randomRange = 5f;
    public float fireRate;
    private float nextTimeToFire;

    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float fireRateRandomness;

    // Use this for initialization
    void Start()
    {
        FindTarget();
        rb = gameObject.GetComponent<Rigidbody>();
        nextTimeToFire = Time.deltaTime;
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        if (rb == null)
            Debug.Log("PANIC!");

        Vector3 difference = target.transform.position - transform.position;
        direction.Normalize();
        direction = Matrix4x4.Rotate(Quaternion.Euler(new Vector3(-30, 0, 0))) * new Vector4(direction.x, direction.y, direction.z, 1);
        xAmount = difference.x;
        yAmount = difference.z;
        animator.SetFloat("X", xAmount, 0.1f, Time.deltaTime);
        animator.SetFloat("Y", yAmount, 0.1f, Time.deltaTime);


        if(Vector3.Distance(target.transform.position, transform.position) > minDistanceToTarget)
        {
            direction = (target.transform.position - gameObject.transform.position);
            direction.Normalize();
            direction = Matrix4x4.Rotate(Quaternion.Euler(new Vector3(-30, 0, 0))) * new Vector4(direction.x, direction.y, direction.z, 1);
            gameObject.transform.Translate(direction * speed);
            //rb.velocity = (direction * speed) + (target.GetComponent<Rigidbody>().velocity);
            //rb.MovePosition(direction * speed);
        }
        else
        {
            Vector3 randomTarget = new Vector3(Random.value* randomRange, Random.value* randomRange, Random.value* randomRange) + gameObject.transform.position;
            if(Vector3.Distance(randomTarget, transform.position) > 0.5f)
            {
                Vector3 randomDirection = (randomTarget - gameObject.transform.position);
                direction = Matrix4x4.Rotate(Quaternion.Euler(new Vector3(-30, 0, 0))) * new Vector4(direction.x, 0, direction.z, 1);
                gameObject.transform.Translate(direction * speed);
            }
        }

        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = fireRate + Time.time + Random.Range(-fireRateRandomness, fireRateRandomness);
            Shoot();
        }

    }

    private void Update()
    {
    }

    public void FindTarget()
    {
        Debug.Log("Finding Target");
        target = GameObject.FindGameObjectsWithTag("Player")[0];
        if (target == null)
        {
            Debug.Log("target not found");
        }
    }

    public void Shoot()
    {
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = dir * bulletSpeed;

    }

    //void FixedUpdate()
    //{
    //    direction = (target.position - gameObject.transform.position).normalized;
    //    gameObject.GetComponent<Rigidbody2D>().MovePosition(direction * speed);
    //    //rb.MovePosition(direction * speed);
    //}
}
