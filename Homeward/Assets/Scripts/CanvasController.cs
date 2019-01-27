using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public GameObject i1;
    public GameObject i2;
    public GameObject i3;
    public GameObject i4;
    public GameObject i5;
    public GameObject i6;
    public GameObject i7;
    public GameObject i8;
    public GameObject i9;
    public string mapName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked!");
            if (i1.activeSelf)
                i1.SetActive(false);
            else if (i2.activeSelf)
                i2.SetActive(false);
            else if(i3.activeSelf)
                i3.SetActive(false);
            else if(i4.activeSelf)
                i4.SetActive(false);
            else if(i5.activeSelf)
                i5.SetActive(false);
            else if(i6.activeSelf)
                i6.SetActive(false);
            else if(i7.activeSelf)
                i7.SetActive(false);
            else if(i8.activeSelf)
                i8.SetActive(false);
            else if(i9.activeSelf)
                i9.SetActive(false);
            else
                SceneManager.LoadScene(mapName);

        }
    }

}
