using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekPlayer : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    public GameObject bombard;
    public GameObject laser;
    public GameObject face;
    public Animator bombardAnimator;
    public Animator laserAnimator;

    public float fireRate;
    private float nextTimeToFire;
    Rigidbody rb;
    public float fireRateRandomness;
    public float fireRateRandomness2;
    public GameObject bulletPrefab;
    public GameObject pelletPrefab;
    public float bulletSpeed;
    public float pelletSpeed;
    public float spread;

    [Range(0f, 180f)]
    public float bombardAngle;
    [Range(0f, 180f)]
    public float laserAngle;
    [Range(0f, 180f)]
    public float faceAngle;
    public Vector3 startingAngle = new Vector3(-1, 0, 0);
    public float speed = 1;
    public float randomRange = 10;

    Vector3 bombardDir;
    Vector3 laserDir;
    Vector3 faceDir;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        FindTarget();
        rb = gameObject.GetComponent<Rigidbody>();
        nextTimeToFire = Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //wack waving inflatable arm flailing alien chungus action
        bombardDir = player.transform.position - bombard.transform.position;
        bombardDir.Normalize();
        bombardAngle = Vector3.Angle(startingAngle, bombardDir);

        laserDir = player.transform.position - laser.transform.position;
        laserDir.Normalize();
        laserAngle = Vector3.Angle(startingAngle, laserDir);

        faceDir = player.transform.position - face.transform.position;
        faceDir.Normalize();
        faceAngle = Vector3.Angle(startingAngle, faceDir);

        bombardAnimator.SetFloat("bombard", bombardAngle / 180);
        laserAnimator.SetFloat("laser", laserAngle / 180);
        if(faceAngle < 90)
        {
            face.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            face.GetComponent<SpriteRenderer>().flipX = true;
        }

        //movement
        Vector3 randomTarget = new Vector3(Random.Range(-1, 1) * randomRange, 0,0) + gameObject.transform.position;

        /*if(Vector3.Distance(randomTarget, transform.position) > 0.5f)
        {
            Vector3 randomDirection = (randomTarget - gameObject.transform.position);
            //direction = Matrix4x4.Rotate(Quaternion.Euler(new Vector3(-30, 0, 0))) * new Vector4(direction.x, 0, direction.z, 1);
            gameObject.transform.Translate(randomDirection * speed);
        }*/

        //shooty shoot
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = fireRate + Time.time + Random.Range(-fireRateRandomness, fireRateRandomness);
            Shoot();
        }

        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = fireRate + Time.time + Random.Range(-fireRateRandomness2, fireRateRandomness2);
            ShootShotgun();
        }

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
        GameObject bullet = Instantiate(bulletPrefab, bombard.transform.position + new Vector3(0, 0, -2), bombard.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = dir * bulletSpeed;
    }

    public void ShootShotgun()
    {
        for (int i = -6; i < 6; i++)
        {
            Vector3 pos = target.transform.position;
            pos = Quaternion.AngleAxis(i * spread, Vector3.up) * pos;
            Vector3 dir = pos - transform.position;
            dir.Normalize();
            GameObject pellet = Instantiate(pelletPrefab, transform.position, transform.rotation);
            pellet.GetComponent<Rigidbody>().velocity = dir * pelletSpeed;
        }
    }
}
