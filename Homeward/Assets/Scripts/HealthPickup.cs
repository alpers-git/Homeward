using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private const string GAME_MASTER_STRING = "GameMaster";

    private float STEP = 0.02f;
    private bool ascending = true;

    public float low, high;

    private void Update()
    {
        Vector3 pos = transform.position;
        if (ascending)
        {
            pos.y += STEP;
            if (pos.y >= high)
            {
                ascending = false;
                pos.y = high;
            }
        }
        else
        {
            pos.y -= STEP;
            if (pos.y <= low)
            {
                ascending = true;
                pos.y = low;
            }
        }
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HealthManager hm = other.GetComponent<HealthManager>();
            if(hm.health < 3)
            {
                hm.Heal();
                GameObject.Find(GAME_MASTER_STRING).GetComponent<GameManager>().HealthPickupPickedUp();
                Destroy(gameObject);
            }
        }
    }
}
