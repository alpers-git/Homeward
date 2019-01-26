using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour {

    public Transform target;
    public float damping = 0.5f;
    public float lookAheadFactor = 1f;
    public float lookAheadReturnSpeed = 1f;
    public float lookAheadThreshold = 1f;
    public float restrictXLow, restrictXHigh, restrictYLow, restrictYHigh;
    //public float nextTimeToSeek=0;
    //public float seekDelay = 0.5f;

    //public float offsetX=0;
    //public float offsetY=0;
    public float offsetZ=-3;

    private Vector3 targetsLastPosition;
    private Vector3 currentVelocity;
    private Vector3 lookAheadPosition;

    // Use this for initialization
    void Start ()
    {
        targetsLastPosition = target.position;
        transform.parent = null;
	}
	
	// Update is called once per frame
	void Update ()
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
            bool UpdateLATX = Mathf.Abs(moveDelta.x) > lookAheadThreshold;
            bool UpdateLATY = Mathf.Abs(moveDelta.z) > lookAheadThreshold;
            //bool UpdateLATZ = Mathf.Abs(moveDelta.x) > lookAheadThreshold;

            if (UpdateLATX)
            {
                lookAheadPosition = lookAheadFactor * Vector3.right * Mathf.Sign(moveDelta.x);
            }
            else
            {
                lookAheadPosition = Vector3.MoveTowards(lookAheadPosition, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
            }

            if (UpdateLATY)
            {
                lookAheadPosition = lookAheadFactor * Vector3.forward * Mathf.Sign(moveDelta.z);
            }
            else
            {
                lookAheadPosition = Vector3.MoveTowards(lookAheadPosition, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
            }

            Vector3 aHeadTargetPosition = target.position + lookAheadPosition + Vector3.forward * offsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aHeadTargetPosition, ref currentVelocity, damping);

            newPos = new Vector3(Mathf.Clamp(newPos.x, restrictXLow, restrictXHigh), Mathf.Clamp(newPos.y, restrictYLow, restrictYHigh), newPos.z);

            transform.position = newPos;
            targetsLastPosition = target.position;

        }
    }

    private void SeekTarget()
    {
        /*if (nextTimeToSeek < Time.time)
        {*/
            Debug.Log("Seeking Target");
            target = GameObject.FindGameObjectWithTag("Player").transform;
            /*nextTimeToSeek = Time.time + seekDelay;
        }*/

    }
}
