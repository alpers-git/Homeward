using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 3;
    public Vector3 velocity;
    public bool isAlienBullet; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("Player") && isAlienBullet) || (other.gameObject.CompareTag("Enemy") && !isAlienBullet))
        {
            other.GetComponent<HealthManager>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
