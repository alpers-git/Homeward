using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpacityChanger : MonoBehaviour
{
    public float STEP;

    private Image image;
    private bool ascending;
    
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        Color c = image.color;
        c.a = 0.8f;
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
            if (alpha >= 0.8f)
            {
                ascending = false;
                alpha = 0.8f;
            }
        }
        else
        {
            alpha -= STEP;
            if (alpha <= 0.6f)
            {
                ascending = true;
                alpha = 0.6f;
            }
        }
        newColor.a = alpha;
        image.color = newColor;
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = image.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = image.color;
            newColor.a = Mathf.Lerp(alpha, aValue, t);
            image.color = newColor;
            yield return null;
        }
    }
}