using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnHover : MonoBehaviour
{

    public Transform panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        panel.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        panel.gameObject.SetActive(false);
    }
}
