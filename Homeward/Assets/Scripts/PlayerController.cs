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

    public GameObject gun;

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
    }

    private void OnMouseDown()
    {
        Shoot(Input.mousePosition);
    }

    void Shoot(Vector3 vec)
    {

    }
}
