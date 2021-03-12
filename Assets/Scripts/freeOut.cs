using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class freeOut : MonoBehaviour
{

    void Update(){
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.Touch))
    {
        SceneManager.LoadScene("RealMain");
    }
    }
    
}
