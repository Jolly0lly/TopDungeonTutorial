using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorederEffect : MonoBehaviour
{
    public Texture2D cameraBorderEffect;
    void OnGUI() 
    { 
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), cameraBorderEffect); 
    }

}

