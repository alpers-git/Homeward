using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTarget : MonoBehaviour
{
    public Transform target;
    private Vector3 targetsLastPosition;
    // Start is called before the first frame update
    void Start()
    {
        //targetsLastPosition = target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDelta = new Vector3(target.position.x - targetsLastPosition.x, 0, target.position.z - targetsLastPosition.z);
        if(moveDelta !=Vector3.zero)
            transform.position += moveDelta;
        targetsLastPosition = target.position;

    }
}
