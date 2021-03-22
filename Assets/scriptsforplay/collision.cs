using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class collision : MonoBehaviour
{
    public AudioSource[] pg_sound;
    public string[] tags;
    public static int hitCheck=-1;
    //snare snare_compo;
    //public GameObject snare_obj;
    [SerializeField] public GameObject[] snares;
    public float m_countToStop;
    public double hit_duration=1f;//따닥 방지변수

    void Start()
    {
       // snare_compo = snare_obj.GetComponent<snare>();
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
        hit_duration += Time.deltaTime;
    }

    public void OnCollisionEnter(Collision col)
    {
        if (hit_duration < 0.5)//따닥 방지.
            return;
        Vibrate(50);
        //OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.RTouch);

        for (int i = 0; i < 16; i++)
        {
            if (col.collider.CompareTag(tags[i]))
            {
                pg_sound[i].PlayOneShot(pg_sound[i].clip);
                hitCheck = i;
                if (snares[i].activeSelf)
                { //collision으로는 자식객체 접근 불가능해서 그냥 snare로 접근
                    snares[i].SetActive(false);
                }
                break;
            }
        }
        hit_duration = 0f;//0.5초간 다시 충돌 함수가 호출되지 않도록 구현,, 너무 길다 싶으면 줄일 수도 있구여@ 한 프레임은 0.2초 정도 하는 것 같음.
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
