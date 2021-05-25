using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private Vector3 oldPosition;
    private Vector3 currentPosition;
    private double velocity;
    void Start()
    {
        for (int i=0; i<pg_sound.Length; i++){
            pg_sound[i].volume = Data.volumes[0];
        }
        oldPosition = transform.position;
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

        if (Data.selected_song == 0){
            currentPosition = transform.position;
            var dis = (currentPosition - oldPosition);
            var distance = Math.Sqrt(Math.Pow(dis.x,2)+Math.Pow(dis.y,2)+Math.Pow(dis.z,2));
            velocity = distance / Time.deltaTime;
            oldPosition = currentPosition;
            
        }
        
    }

    public void OnCollisionEnter(Collision col)
    {
        if (hit_duration < 0.3){//따닥 방지
            return;
        }
        //OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.RTouch);

        for (int i = 0; i < 16; i++)
        {
            if (col.collider.CompareTag(tags[i]))
            {
                if (Data.selected_song != 0){ //리듬게임 모드
                    pg_sound[i].PlayOneShot(pg_sound[i].clip);
                    Vibrate(50f);
                    //if (snares[i].activeSelf) snares[i].SetActive(false);
                }
                else{ //자유연주모드
                    pg_sound[i].volume = Data.volumes[0] * (float)velocity;
                    pg_sound[i].PlayOneShot(pg_sound[i].clip);
                    Vibrate(50* (float)velocity);
                }
                hitCheck = i;
                break;
            }
        }
        Data.hit_tsample=SoundSystem.bgm.timeSamples;
        hit_duration = 0f;
        Debug.Log("&&&&&&&&&&HIT TIME:  "+SoundSystem.bgm.timeSamples);
    }

    void Vibrate(float ms)
    {
        OVRInput.SetControllerVibration(0.4f, 0.4f, OVRInput.Controller.RTouch);
        m_countToStop = (ms) / 1000;
    }

    void StopVibration()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        m_countToStop = 0;
    }

}
