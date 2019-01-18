using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Imagerewinder : MonoBehaviour
{
    public Image mImageCom;
    public LoadScreenshots mLoader;
    public float mInterval;
    private float mTimer;
    private Sprite[] mSprites;
    private int mShotlength;
    private int mCurrShot;

    public string _myScene;

    // Use this for initialization
    void Start()
    {
        mSprites = mLoader.ReturnImages();
        mShotlength = mSprites.Length;
        mCurrShot = mShotlength;
        mCurrShot--;
        mTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (mTimer >= mInterval)
        {
            if (mCurrShot >= 0)
            {
                mImageCom.sprite = mSprites[mCurrShot];
                Debug.Log(mCurrShot);
            }
            if (mCurrShot < 0)
            {
                Debug.Log("SCENE CHANGE");
                StartCoroutine(Cleanup());
                SceneManager.LoadScene(_myScene);
            }
            mCurrShot--;
            mTimer = 0;
        }
        mTimer += Time.deltaTime;
    }

    string Cleanup()
    {
        DirectoryInfo di = new DirectoryInfo("Assets/screenshots/");
        foreach (FileInfo file in di.GetFiles())
        {
            file.Delete();
        }
        return "Done";
    }
}
