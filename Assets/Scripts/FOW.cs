using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FOW : MonoBehaviour
{
    public Image Fade;
    // Start is called before the first frame update
    void Start()
    {
        Fade.canvasRenderer.SetAlpha(1.0f);//Visible
        fadeOut();
    }

    // Update is called once per frame
    void fadeOut()
    {
        Fade.CrossFadeAlpha(0,2,false);//(Inisible,time,false call)
    }
}
