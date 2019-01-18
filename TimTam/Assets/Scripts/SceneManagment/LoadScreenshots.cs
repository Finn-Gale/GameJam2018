using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadScreenshots : MonoBehaviour
{
    Sprite[] mSprites;
    string[] files;

    // Use this for initialization
    void Start()
    {
        
    }
    public Sprite[] ReturnImages()
    {
        string path = "Assets/screenshots/";
        files = Directory.GetFiles(path, "*.png");
        int nubmeroffiles = files.Length;
        mSprites = new Sprite[nubmeroffiles];
        LoadImages();

        return mSprites;
    }
    private void Update()
    {
        
    }

    private void LoadImages()
    {
        int i = 0;
        foreach (string f in files)
        {
            //Sprite tmpSprite = new Sprite();
            Texture2D SpriteTex = Loadtexture(f);
            Sprite tmpSprite = Sprite.Create(SpriteTex, new Rect(0,0,SpriteTex.width, SpriteTex.height), new Vector2(0,0), 100.0f);

            mSprites[i] = tmpSprite;
            i++;
        }
    }

    private Texture2D Loadtexture(string f)
    {
        Texture2D tex;
        byte[] FileData;

        if (File.Exists(f))
        {
            FileData = File.ReadAllBytes(f);
            tex = new Texture2D(2, 2);
            if (tex.LoadImage(FileData))
                return tex;
        }
        return null;
    }

    //    #region Old
    //    Sprite[] mGameobj;
    //    Texture2D[] mTextures;

    //    string[] files;
    //    string pathPrefix;

    //	// Use this for initialization
    //	void Start ()
    //    {
    //        string path = "{0}/screenshots/";
    //        pathPrefix = @"file://";
    //        files = Directory.GetFiles(path, "*.png");
    //        int nubmeroffiles = files.Length;
    //        mGameobj = new Sprite[nubmeroffiles];
    //        StartCoroutine(LoadImages());

    //	}

    //	// Update is called once per frame
    //	void Update ()
    //    {

    //	}

    //    public Sprite[] GetImages()
    //    {
    //        LoadImages();
    //        return mGameobj;
    //    }

    //    private IEnumerator LoadImages()
    //    {
    //        mTextures = new Texture2D[files.Length];

    //        int dummy = 0;

    //        foreach (string tstring in files)
    //        {
    //            string pathTemp = pathPrefix + tstring;
    //            WWW www = new WWW(pathTemp);
    //            yield return www;
    //            Texture2D texTmp = new Texture2D(1024, 1024, TextureFormat.DXT1, false);
    //            www.LoadImageIntoTexture(texTmp);

    //            mTextures[dummy] = texTmp;

    //            mGameobj[dummy].GetComponent<Renderer>().material.SetTexture("_MainText", texTmp);
    //            dummy++;
    //        }
    //    }
    //#endregion
}
