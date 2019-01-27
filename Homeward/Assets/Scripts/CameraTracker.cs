using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{

    public Transform target;
    public float damping = 0.5f;
    public float lookAheadFactor = 0.01f;
    public float restrictXLow, restrictXHigh, restrictYLow, restrictYHigh;
    public float maxDistanceFromTarget;
    //public float nextTimeToSeek=0;
    //public float seekDelay = 0.5f;

    //public float offsetX=0;
    //public float offsetY=0;

    private Vector3 targetsLastPosition;
    private Vector3 currentVelocity;
    private Vector3 lookAheadPosition;
    private Vector3 initialDistance;

    // Use this for initialization
    void Start()
    {
        SeekTarget();
        targetsLastPosition = target.position;
        transform.parent = null;
        initialDistance = - target.position + transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (target == null && (GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>().isAlive))
        {
            SeekTarget();
            //Debug.Log("1");
        }
        else if (target == null && !(GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>().isAlive))
        {
            //Debug.Log("2");
            return;
        }*/
        if (target == null)
            SeekTarget();
        //return;
        else
        {
            //Debug.Log("3");
            Vector3 moveDelta = (target.position - targetsLastPosition);
            Vector3 aheadPos =new Vector3();

            aheadPos = (new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y) - new Vector3(Screen.width/2, 0, Screen.height / 2)) * lookAheadFactor;
            //aheadPos = Vector3.ClampMagnitude(aheadPos, maxDistanceFromTarget);
            Vector3 finalPos = moveDelta + transform.position + aheadPos;
            finalPos = new Vector3(Mathf.Clamp(finalPos.x, target.position.x + initialDistance.x - maxDistanceFromTarget, target.position.x + initialDistance.x + maxDistanceFromTarget),
                finalPos.y, 
                Mathf.Clamp(finalPos.z, target.position.z + initialDistance.z - maxDistanceFromTarget, target.position.z + initialDistance.z + maxDistanceFromTarget));

            //if ((finalPos - target.position).magnitude > maxDistanceFromTarget)

            Vector3 newPos = Vector3.SmoothDamp(transform.position, finalPos, ref currentVelocity, damping);
            newPos = new Vector3(Mathf.Clamp(newPos.x, restrictXLow, restrictXHigh), newPos.y, Mathf.Clamp(newPos.z, restrictYLow, restrictYHigh));

            transform.position = newPos;
            targetsLastPosition = target.position;

        }
    }

    private void SeekTarget()
    {
        /*if (nextTimeToSeek < Time.time)
        {*/
        target = GameObject.FindGameObjectWithTag("Player").transform;
        /*nextTimeToSeek = Time.time + seekDelay;
    }*/

    }
}
