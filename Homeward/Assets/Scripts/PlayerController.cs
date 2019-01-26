using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 4f;
    public float restrictXLow = -22.5f;
    public float restrictXHigh = 22.5f;
    public float restrictYLow = - 11;
    public float restrictYHigh = 11;

    public Animator animator;
    float xAmount;
    float yAmount;

    public GameObject gunTip;
    public GameObject bulletPrefab;
    public float bulletSpeed = 4f;
    public float bulletLife = 3f;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        /*Vector2 origin = new Vector2(Screen.width/2, Screen.height/2);
        Vector2 difference = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - origin;*/
        Vector3 difference = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        xAmount = difference.x;
        yAmount = difference.y;
        animator.SetFloat("X", xAmount, 0.1f, Time.deltaTime);
        animator.SetFloat("Y", yAmount, 0.1f, Time.deltaTime);
        float inputV = Input.GetAxis("Vertical");
        float inputH = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody>().useGravity = false;

        /*GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * inputV);
        GetComponent<Rigidbody>().AddForce(gameObject.transform.right * speed * inputH);*/

        GetComponent<Rigidbody>().MovePosition(transform.position + Vector3.forward * speed * inputV +
            gameObject.transform.right* speed *inputH);

        Vector3 restrictedPos = new Vector3(Mathf.Clamp(gameObject.transform.position.x, restrictXLow, restrictXHigh),
                                           Mathf.Clamp(gameObject.transform.position.y, 0, 0),
                                          Mathf.Clamp(gameObject.transform.position.z, restrictYLow, restrictYHigh));
        transform.eulerAngles = new Vector3(30, 0, Mathf.Sin((transform.position.x + transform.position.z) * 1) * 5);

       gameObject.transform.position = restrictedPos;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 bulletDirection = hit.point - transform.position;
                bulletDirection.Normalize();
                bulletDirection.y = 0;
                Shoot(bulletDirection);
            }
            //Debug.Log(gameObject.transform.rotation.x + " " + gameObject.transform.rotation.y);
        }
    }

    void Shoot(Vector3 dir)
    {
        Vector3 pos = new Vector3(gunTip.transform.position.x, 0f, gunTip.transform.position.z);
        GameObject bullet = Instantiate(bulletPrefab, pos, transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = dir * bulletSpeed;
    }
}
