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
    public Transform gameOverUI;

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
                UpdateUI();
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

    public void Heal(int hpAmount = 1)
    {
        if(hpAmount > 0)
        {
            health += hpAmount;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
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
                for (int i = 0; i < gameOverUI.childCount; i++)
                {
                    Component child = gameOverUI.GetChild(i);
                    child.GetComponent<OpacityChanger>().StartAnimation(0.0f, 1.0f, 0.7f, 1.0f, 0.005f);
                }
                break;
            default:
                break;
        }
    }
}
