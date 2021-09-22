using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpriteResizer : MonoBehaviour
{
    private Image image;
    private Vector2 imageResolution;
    private 
    void Start()
    {
        imageResolution = image.rectTransform.sizeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ImageResize(Vector2 imageResolution)
    {

    }

}
