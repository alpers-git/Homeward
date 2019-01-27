using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public int doorNum;
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
        if(other.gameObject.tag =="Player" && GameObject.Find("GameMaster").GetComponent<GameManager>().AreDoorsUnlocked() 
            && doorNum != GameObject.Find("GameMaster").GetComponent<GameManager>().GetLastDoor())
        {
            GameObject.Find("GameMaster").GetComponent<GameManager>().SwitchRoom(doorNum);
        }
    }
}
