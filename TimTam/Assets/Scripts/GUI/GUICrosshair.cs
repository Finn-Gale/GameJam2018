using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUICrosshair : MonoBehaviour
{
    public Texture2D crosshairTexture;
    public Texture2D activeTexture;
    public Rect position;
    private bool mActive = false;
    public static bool OriginalOn = true;

    public bool Active
    {
        get { return mActive; }
    }

    // Use this for initialization
    void Start()
    {
        position = new Rect((Screen.width - crosshairTexture.width) / 2, (Screen.height - crosshairTexture.height) / 2,
            crosshairTexture.width, crosshairTexture.height);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetActive()
    {
        mActive = true;
    }
    public void setNotActive()
    {
        mActive = false;
    }

    private void OnGUI()
    {
        if (OriginalOn == true)
        {
            if (!mActive)
                GUI.DrawTexture(position, crosshairTexture);
            else if (mActive)
                GUI.DrawTexture(position, activeTexture);
        }

    }
}
