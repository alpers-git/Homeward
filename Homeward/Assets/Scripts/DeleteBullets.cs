using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBullets : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
            Destroy(other.gameObject);
    }
}
