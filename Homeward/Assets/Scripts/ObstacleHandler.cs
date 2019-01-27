using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    public float offset = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
        else
        {
            Vector3 dir = transform.position - other.transform.position;
            dir.Normalize();
            dir.y = 0;
            other.transform.Translate(-dir* offset);
        }
    }

}
