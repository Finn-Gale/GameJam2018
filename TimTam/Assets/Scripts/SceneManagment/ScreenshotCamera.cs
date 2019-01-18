using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

// https://answers.unity.com/questions/22954/how-to-save-a-picture-take-screenshot-from-a-camer.html

public class ScreenshotCamera : MonoBehaviour
{
    public int resWidth = 2550;
    public int resHeight = 3300;

    // Second thread for screenshot process
    Thread ChildThread;
    EventWaitHandle ChildThreadWait;
    EventWaitHandle MainThreadWait;

    // Screenshot variables
    RenderTexture rt;
    Texture2D screenShot;
    public static string ScreenShotName(int width, int height)
    {
        return string.Format("{0}/screenshots/screen_{1}x{2}_{3}.png",
                             Application.dataPath,
                             width, height,
                             System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    // Use this for initialization
    void Start()
    {
        //ChildThread = null;
       // ChildThreadWait = new EventWaitHandle(true, EventResetMode.ManualReset);
        //MainThreadWait = new EventWaitHandle(true, EventResetMode.ManualReset);
    }

    // Update is called once per frame
    void Update()
    {
        //ChildThreadWait.Set();
    }

    public void TakeScreenshot()
    {
        //Awake();
        //takeShot();
    }

    //void ChildThreadLoop()
    //{
    //    ChildThreadWait.Reset();
    //    ChildThreadWait.WaitOne();
    //    while(true)
    //    {
    //        ChildThreadWait.Reset();
    //        takeShot();
    //        WaitHandle.SignalAndWait(MainThreadWait, ChildThreadWait);
    //    }
    //}

    //private void Awake()
    //{
    //    ChildThread = new Thread(ChildThreadLoop);
    //    ChildThread.Start();
        
    //}

    private void takeShot()
    {
        rt = new RenderTexture(resWidth, resHeight, 24);
        screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        GetComponent<Camera>().targetTexture = rt;       
        GetComponent<Camera>().Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        GetComponent<Camera>().targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = ScreenShotName(resWidth, resHeight);
        System.IO.File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("Took screenshot to: {0}", filename));
    }
}
