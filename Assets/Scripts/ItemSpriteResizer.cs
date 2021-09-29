using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpriteResizer : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Image imageHolder;
    private Vector2 imageResolution;
    private Vector2 imageHolderResolution;

    private void Start()
    {
        image = gameObject.transform.GetChild(0).GetComponent<Image>();
        imageHolder = gameObject.GetComponent<Image>();
    }
    private void OnEnable()
    {
        ImageResize();
    }

    public void ImageResize()
    {
        if (image == null || image.sprite == null)
            return;
        imageResolution = image.rectTransform.sizeDelta;
        imageHolderResolution = imageHolder.rectTransform.sizeDelta;
        imageResolution = new Vector2(image.sprite.rect.width, image.sprite.rect.height);
        for (float sizeScale = 0; imageResolution.x < imageHolderResolution.x && imageResolution.y < imageHolderResolution.y; sizeScale++)
        {
            imageResolution.x *= 1.5f;
            imageResolution.y *= 1.5f;
            image.rectTransform.sizeDelta = imageResolution;
            sizeScale++;
        }

        if(imageResolution.x > imageHolderResolution.x || imageResolution.y > imageHolderResolution.y)
        {
            imageResolution.x /= 1.5f;
            imageResolution.y /= 1.5f;
            image.rectTransform.sizeDelta = imageResolution;
        }

        
    }
}


            
