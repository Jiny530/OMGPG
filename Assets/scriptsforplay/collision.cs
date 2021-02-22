using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class collision : MonoBehaviour
{
    public AudioSource[] pg_sound;  //pg1, pg2, pg3, pg4, pg5, pg6, pg7, pg8, pg9, pg10, pg11, pg12, pg13, pg14, pg15, pg16;
    //public GameObject[] pyeongyeong;  //PG1, PG2, PG3, PG4, PG5, PG6, PG7, PG8, PG9, PG10, PG11, PG12, PG13, PG14, PG15, PG16;
    public string[] tags;
    public static int hitCheck;
    snare snares;
    public float m_countToStop;

    void Start()
    {
        snares = GetComponent<snare>();
    }

    void Update()
    {
        if (m_countToStop >= 0f)
        {
            m_countToStop -= Time.deltaTime;
            if (m_countToStop <= 0f)
            {
                StopVibration();
            }
        }
    }


    public void OnCollisionEnter(Collision col)
    {
        Vibrate(50);
        //OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.RTouch);

        for (int i = 0; i < 16; i++)
        {
            if (col.collider.CompareTag(tags[i]))
            {
                pg_sound[i].PlayOneShot(pg_sound[i].clip);
                hitCheck = i;
                if (snares.snares[i].activeSelf == true)
                { //collision으로는 자식객체 접근 불가능해서 그냥 snare로 접근
                    snares.snares[i].SetActive(false);
                }
                break;
            }
        }

        
    }

    void Vibrate(int ms)
    {
        OVRInput.SetControllerVibration(0.4f, 0.4f, OVRInput.Controller.RTouch);
        m_countToStop = ((float)ms) / 1000;
    }

    void StopVibration()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        m_countToStop = 0;

    }
}
