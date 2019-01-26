using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TrackMouse : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
        if (Input.mousePosition.x == 0 || Input.mousePosition.y == 0 || Input.mousePosition.x >= Handles.GetMainGameViewSize().x - 1 || Input.mousePosition.y >= Handles.GetMainGameViewSize().y - 1) return;
#else
    if (Input.mousePosition.x == 0 || Input.mousePosition.y == 0 || Input.mousePosition.x >= Screen.width - 1 || Input.mousePosition.y >= Screen.height - 1) return;
#endif
        Vector3 difference = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        difference.Normalize();


        float rotationDegree = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.Euler(30f, 0f, rotationDegree);
	}
}
