using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f; // the fading speed

    public int drawDepth = -1000; //
    private float alpha = 1.0f;
    private int fadeDir = -1; //  the direction to fade. in = -1, out = 1

    private void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        // fore clamp the number beween 0 and 1
        alpha = Mathf.Clamp01(alpha);
        //set color
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha); //  set the alpha value
        GUI.depth = drawDepth;                                              // make the black textures render on top
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }
    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }
    private void OnLevelFinishedLoading()
    {
        BeginFade(-1);
    }
}
