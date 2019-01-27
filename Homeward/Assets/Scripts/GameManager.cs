using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private const string CLOSED_DOOR_STRING = "door_blue";
    private const string OPEN_DOOR_STRING = "door_open";
    private const string LOCKED_DOOR_STRING = "door_red";

    public GameObject healthUp;
    public GameObject[] rooms;
    public GameObject[] Enemies;
    public BoxCollider[] doorColliders;
    public Vector3 maxBoundaries, minBoudaries;
    public GameObject Player;
    public GameObject bossroom;
    public GameObject boss;

    public int numOfWavesPerRoom;
    public float healthPickupSpawnInterval;

    private bool isHealthPickupPickedUp = true;

    private int roomNum;
    private List<GameObject> Enemywave;
    private int currentWave;
    private float lastHealthPickupTime;
    private bool areDoorsUnlocked;
    private GameObject currentRoom;
    private int lastDoor = 1;
    // Start is called before the first frame update
    void Start()
    {
        roomNum = 1;
        lastHealthPickupTime = Time.time;
        Enemywave = new List<GameObject>();
        currentRoom = Instantiate(rooms[Random.Range(0, rooms.Length)], new Vector3(-8.7627f, -63.050f, 114.4918f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (roomNum < 10)
        {
            if (numOfWavesPerRoom >= currentWave)
            {
                //Debug.Log("numOfWavesPerRoom > currentWave");
                if (Enemywave.Count == 0)
                {
                    //Debug.Log("Spawn Wave");
                    SpawnWave();
                }
                if (Time.time >= lastHealthPickupTime && isHealthPickupPickedUp)
                {
                    //Debug.Log("Spawn HP");
                    SpawnHealthPickup();
                }
            }
            else
            {
                //Debug.Log("Unlock Doors");
                UnlockDoors();
            }
        }
        else
        {
            SpawnBossRoom();
        }
        //Debug.Log("UPDATE");
        
    }

    private void SpawnBossRoom()
    {
        Destroy(currentRoom);
        currentRoom = Instantiate(bossroom, new Vector3(-8.7627f, -63.050f, 114.4918f), Quaternion.identity);
        Instantiate(Enemies[Random.Range(0, Enemies.Length)], new Vector3(8.5f, 0, -80), Quaternion.Euler(30, 0, 0));
        for(int i = 0; i < doorColliders.Length; i++)
        {
            doorColliders[i].gameObject.SetActive(false);
        }
    }

    private void SpawnHealthPickup()
    {
        float randomX = Random.Range(minBoudaries.x, maxBoundaries.x);
        float randomZ = Random.Range(minBoudaries.z, maxBoundaries.z);
        Instantiate(healthUp, new Vector3(randomX, -0.5f, randomZ), Quaternion.identity);
        isHealthPickupPickedUp = false;
    }

    private void SpawnWave()
    {
        for(int i = 0; i < roomNum; i++)
        {
            float randomX = Random.Range(minBoudaries.x, maxBoundaries.x);
            float randomZ = Random.Range(minBoudaries.z, maxBoundaries.z);
            Enemywave.Add(Instantiate(Enemies[Random.Range(0, Enemies.Length)], new Vector3(randomX, 0, randomZ), Quaternion.Euler(30, 0, 0)));
        }
        currentWave++;
    }
    public int GetLastDoor()
    {
        return lastDoor;
    }

    private void UnlockDoors()
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
        foreach (GameObject door in doors)
        {
            if(!door.transform.Find(LOCKED_DOOR_STRING).gameObject.activeSelf)
            {
                door.transform.Find(CLOSED_DOOR_STRING).gameObject.SetActive(false);
                door.transform.Find(OPEN_DOOR_STRING).gameObject.SetActive(true);
            }
        }
        areDoorsUnlocked = true;
    }
    public bool AreDoorsUnlocked()
    {
        return areDoorsUnlocked;
    }

    public void SwitchRoom(int doorId)
    {
        areDoorsUnlocked = false;
        Destroy(currentRoom);
        currentRoom = Instantiate(rooms[Random.Range(0, rooms.Length)], new Vector3(-8.7627f, -63.050f, 114.4918f), Quaternion.identity);
        int roomNum = (int)Char.GetNumericValue(currentRoom.name[currentRoom.name.Length - 8]);
        GameObject entranceDoor;
        int direction = 1;
        lastDoor = doorId;
        switch (doorId)
        {
            case 0:
                direction = 0;
                entranceDoor = GameObject.Find("/Room" + roomNum + "(Clone)/Door2");
                entranceDoor.transform.Find(CLOSED_DOOR_STRING).gameObject.SetActive(false);
                entranceDoor.transform.Find(LOCKED_DOOR_STRING).gameObject.SetActive(true);
                Debug.Log(entranceDoor);
                break;
            case 1:
                direction = 1;
                break;
            case 2:
                direction = 2;
                entranceDoor = GameObject.Find("/Room" + roomNum + "(Clone)/Door0");
                entranceDoor.transform.Find(CLOSED_DOOR_STRING).gameObject.SetActive(false);
                entranceDoor.transform.Find(LOCKED_DOOR_STRING).gameObject.SetActive(true);
                break;
            default:
                break;
        }
        roomNum++;
        currentWave = 0;
        if (direction == 0)
        {
            Player.transform.position = new Vector3(23, 0, 18);
        }
        else if (direction == 1)
        {
            Player.transform.position = new Vector3(0, 0, 0);
        }
        else if (direction == 2)
        {
            Player.transform.position = new Vector3(-23, 0, 18);
        }
    }

    public void HealthPickupPickedUp()
    {
        isHealthPickupPickedUp = true;
        lastHealthPickupTime = Time.time + healthPickupSpawnInterval;
    }

    public void Kill(GameObject enemy)
    {
        Enemywave.Remove(enemy);
    }

    private IEnumerator scheduleTeleport(int direction)
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("YEA");
        if(direction == 0)
        {
            Player.transform.position = new Vector3(23, 0, 18);
        }
        else if(direction == 1)
        {
            Player.transform.position = new Vector3(0, 0, 0);
        }
        else if(direction == 2)
        {
            Player.transform.position = new Vector3(-23, 0, 18);
        }
    }
}
