using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpacityChanger : MonoBehaviour
{
    public float STEP;
    public float low;
    public float high;

    private Image image;
    private bool ascending;
    
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        Color c = image.color;
        c.a = high;
        image.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        Color newColor = image.color;
        float alpha = image.color.a;
        if(ascending)
        {
            alpha += STEP;
            if (alpha >= high)
            {
                ascending = false;
                alpha = high;
            }
        }
        else
        {
            alpha -= STEP;
            if (alpha <= low)
            {
                ascending = true;
                alpha = low;
            }
        }
        newColor.a = alpha;
        image.color = newColor;
    }

    public void StartAnimation(float start, float end, float low, float high, float step = 0)
    {
        image = GetComponent<Image>();
        Color c = image.color;
        c.a = start;
        image.color = c;
        this.low = low;
        this.high = high;
        this.ascending = true;
        if(step != 0)
        {
            this.STEP = step;
        }
    }
}