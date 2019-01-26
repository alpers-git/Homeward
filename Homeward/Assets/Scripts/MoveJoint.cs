using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveJoint : MonoBehaviour
{
    public Vector3 pos0;
    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;
    public Vector3 pos4;
    public Vector3 pos5;
    public Vector3 pos6;
    public Vector3 pos7;

    private Transform elbowTransform;
    public Sprite backHand;
    public Sprite foreHand;

    // Start is called before the first frame update
    void Start()
    {
        elbowTransform = this.gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
/*#if UNITY_EDITOR
        if (Input.mousePosition.x == 0 || Input.mousePosition.y == 0 || Input.mousePosition.x >= Handles.GetMainGameViewSize().x - 1 || Input.mousePosition.y >= Handles.GetMainGameViewSize().y - 1) return;
#else
    if (Input.mousePosition.x == 0 || Input.mousePosition.y == 0 || Input.mousePosition.x >= Screen.width - 1 || Input.mousePosition.y >= Screen.height - 1) return;
#endif*/
        Vector3 difference = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        float rotationDegree = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg + 180;
        //Debug.Log(rotationDegree);

        if(337.5<= rotationDegree || rotationDegree < 22.5)
        {
            this.gameObject.transform.GetChild(0).position = this.transform.position + pos0;
        }
        else if (22.5 <= rotationDegree && rotationDegree < 67.5)
        {
            this.gameObject.transform.GetChild(0).position = this.transform.position + pos1;
        }
        else if (67.5 <= rotationDegree && rotationDegree < 112.5)
        {
            this.gameObject.transform.GetChild(0).position = this.transform.position + pos2;
        }
        else if (112.5 <= rotationDegree && rotationDegree < 157.5)
        {
            this.gameObject.transform.GetChild(0).position = this.transform.position + pos3;
        }
        else if (157.5 <= rotationDegree && rotationDegree < 202.5)
        {
            this.gameObject.transform.GetChild(0).position = this.transform.position + pos4;
        }
        else if (202.5 <= rotationDegree && rotationDegree < 247.5)
        {
            this.gameObject.transform.GetChild(0).position = this.transform.position + pos5;
        }
        else if (247.5 <= rotationDegree && rotationDegree < 292.5)
        {
            this.gameObject.transform.GetChild(0).position = this.transform.position + pos6;
        }
        else if (292.5 <= rotationDegree && rotationDegree < 337.5)
        {
            this.gameObject.transform.GetChild(0).position = this.transform.position + pos7;
        }
        else
        {
            Debug.Log("ERROR: MoveJoint#Update() line 72! Shouldn't come here!");
        }

        if (0<= rotationDegree && rotationDegree < 157.5)
        {
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = foreHand;
        }
        else if (157.5 <= rotationDegree && rotationDegree < 360)
        {
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = backHand;
        }

        /*
        if (-22.5f <= rotationDegree && rotationDegree <= 22.5f)
            this.gameObject.transform.GetChild(0).position = this.transform.position + pos0;
        else if(22.5f < rotationDegree && rotationDegree <= 67.5f)
            this.gameObject.transform.GetChild(0).position = this.transform.position + pos1;
        else if (67.5f < rotationDegree && rotationDegree <= 112.5f)
            this.gameObject.transform.GetChild(0).position = this.transform.position + pos2;
        else if (112.5f < rotationDegree && rotationDegree <= 157.5f)
            this.gameObject.transform.GetChild(0).position = this.transform.position + pos3;
        else if (157.5f < rotationDegree && rotationDegree <= -157.5f)
            this.gameObject.transform.GetChild(0).position = this.transform.position + pos4;
        else if (-157.5f < rotationDegree && rotationDegree <= -112.5f)
            this.gameObject.transform.GetChild(0).position = this.transform.position + pos5;
        else if (-112.5f < rotationDegree && rotationDegree <= -67.5f)
            this.gameObject.transform.GetChild(0).position = this.transform.position + pos6;
        else
            this.gameObject.transform.GetChild(0).position = this.transform.position + pos7;
            */
    }
}
