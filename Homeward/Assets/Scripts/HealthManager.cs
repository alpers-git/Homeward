using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image leftFull;
    public Image leftEmpty;
    public Image middleFull;
    public Image middleEmpty;
    public Image rightFull;
    public Image rightEmpty;
    public bool isHenry;
    public float invulTime;

    private float nextTimeToTakeDamage;
    public int health = 3;

    public void Start()
    {
        nextTimeToTakeDamage = Time.deltaTime;
    }

    public void TakeDamage(int dmg = 1)
    {
        if(isHenry)
        {
            if(Time.time >= nextTimeToTakeDamage)
            {
                health -= dmg;
                nextTimeToTakeDamage = invulTime + Time.time;
                switch (health)
                {
                    case 3:
                        leftFull.gameObject.SetActive(true);
                        middleFull.gameObject.SetActive(true);
                        rightFull.gameObject.SetActive(true);
                        leftEmpty.gameObject.SetActive(false);
                        middleEmpty.gameObject.SetActive(false);
                        rightEmpty.gameObject.SetActive(false);
                        break;
                    case 2:
                        leftFull.gameObject.SetActive(true);
                        middleFull.gameObject.SetActive(true);
                        rightFull.gameObject.SetActive(false);
                        leftEmpty.gameObject.SetActive(false);
                        middleEmpty.gameObject.SetActive(false);
                        rightEmpty.gameObject.SetActive(true);
                        break;
                    case 1:
                        leftFull.gameObject.SetActive(true);
                        middleFull.gameObject.SetActive(false);
                        rightFull.gameObject.SetActive(false);
                        leftEmpty.gameObject.SetActive(false);
                        middleEmpty.gameObject.SetActive(true);
                        rightEmpty.gameObject.SetActive(true);
                        break;
                    case 0:
                        leftFull.gameObject.SetActive(false);
                        middleFull.gameObject.SetActive(false);
                        rightFull.gameObject.SetActive(false);
                        leftEmpty.gameObject.SetActive(true);
                        middleEmpty.gameObject.SetActive(true);
                        rightEmpty.gameObject.SetActive(true);
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            health -= dmg;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
