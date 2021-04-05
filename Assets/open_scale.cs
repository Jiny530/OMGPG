using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class open_scale : MonoBehaviour
{
    public GameObject scales;
    public GameObject info;
    public GameObject pg;
    // Update is called once per frame
    void Start(){
    }
    void Update()
    {
        if (info.activeSelf && (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.Touch) || OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.Touch))){
            scales.SetActive(true);
            info.SetActive(false);
        }
        if (!info.activeSelf && OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.Touch))
        {
            SceneManager.LoadScene("RealMain");
        }
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.Touch))
        {
            if (scales.activeSelf) scales.SetActive(false);
            else scales.SetActive(true);
        }
    }
}
