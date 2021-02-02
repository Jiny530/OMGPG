using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public AudioSource[] pg_sound;  //pg1, pg2, pg3, pg4, pg5, pg6, pg7, pg8, pg9, pg10, pg11, pg12, pg13, pg14, pg15, pg16;
    public GameObject[] pyeongyeong;  //PG1, PG2, PG3, PG4, PG5, PG6, PG7, PG8, PG9, PG10, PG11, PG12, PG13, PG14, PG15, PG16;

    void OnEnable(){
        pyeongyeong = new GameObject[16];
        pg_sound = new AudioSource[16];
    /*
        for (int i=0;i<16;i++){
            pyeongyeong[i] = pyeongyeong.GetChild(i).gameObject;
            pg_sound[i] = pg_sound.GetChild(i).gameObject;
        }*/
    }
    public void Start (){

    }

    /*
    PG1 = GameObject.Find("1");
    PG2 = GameObject.Find("2");
    PG3 = GameObject.Find("3");
    PG4 = GameObject.Find("4");
    PG5 = GameObject.Find("5");
    PG6 = GameObject.Find("6");
    PG7 = GameObject.Find("7");
    PG8 = GameObject.Find("8");
    PG9 = GameObject.Find("9");
    PG10 = GameObject.Find("10");
    PG11 = GameObject.Find("11");
    PG12 = GameObject.Find("12");
    PG13 = GameObject.Find("13");
    PG14 = GameObject.Find("14");
    PG15 = GameObject.Find("15");
    PG16 = GameObject.Find("16");
    */

    public void OnCollisionEnter(Collision trig)
    {   

        for (int i = 0; i<16; i++){
            
        }
        /*
        if (PG1) pg1.PlayOneShot(pg1.clip); 
        if (PG2) pg2.PlayOneShot(pg2.clip); 
        if (PG3) pg3.PlayOneShot(pg3.clip); 
        if (PG4) pg4.PlayOneShot(pg4.clip); 
        if (PG5) pg5.PlayOneShot(pg5.clip);
        if (PG6) pg6.PlayOneShot(pg6.clip); 
        if (PG7) pg7.PlayOneShot(pg7.clip); 
        if (PG8) pg8.PlayOneShot(pg8.clip); 
        if (PG9) pg9.PlayOneShot(pg9.clip); 
        if (PG10) pg10.PlayOneShot(pg10.clip); 
        if (PG11) pg11.PlayOneShot(pg11.clip); 
        if (PG12) pg12.PlayOneShot(pg12.clip); 
        if (PG13) pg13.PlayOneShot(pg13.clip); 
        if (PG14) pg14.PlayOneShot(pg14.clip); 
        if (PG15) pg15.PlayOneShot(pg15.clip); 
        if (PG16) pg16.PlayOneShot(pg16.clip); 
        */
    }
}
