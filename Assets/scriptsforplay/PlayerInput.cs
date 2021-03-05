﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public static Vector3[] effect_positions;
    [SerializeField] GameObject[] judgePrefab = null;//판정 이미지
    [SerializeField] GameObject[] judgePos=null;

    void set_effect_positions()
    {
        effect_positions=new Vector3[16];

        effect_positions[15] = new Vector3(-1.123f,0.296f,-0.228f);            
        effect_positions[14] = new Vector3(-0.818f,0.296f,-0.228f);
        effect_positions[13] = new Vector3(-0.473f,0.296f,-0.228f);
        effect_positions[12] = new Vector3(-0.155f,0.296f,-0.228f);
        effect_positions[11] = new Vector3( 0.136f,0.296f,-0.228f);
        effect_positions[10] = new Vector3( 0.428f,0.296f,-0.228f);
        effect_positions[9]  = new Vector3( 0.806f,0.296f,-0.228f);
        effect_positions[8]  = new Vector3( 1.105f,0.296f,-0.228f);

        effect_positions[7]  = new Vector3( 1.105f, -0.472f, -0.472f);
        effect_positions[6]  = new Vector3( 0.806f, -0.472f, -0.472f);
        effect_positions[5]  = new Vector3( 0.428f, -0.472f, -0.472f);
        effect_positions[4]  = new Vector3( 0.136f, -0.472f, -0.472f);
        effect_positions[3]  = new Vector3( -0.155f, -0.472f, -0.472f);
        effect_positions[2]  = new Vector3( -0.473f, -0.472f, -0.472f);
        effect_positions[1]  = new Vector3( -0.818f, -0.472f, -0.472f);
        effect_positions[0]  = new Vector3( -1.123f, -0.472f, -0.472f);
    }

    TimingManager theTimingManager;
    public int timeVal;
    public static int playScore;
   

    private void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();
        set_effect_positions();
    }

    void Update()
    {
        if (collision.hitCheck!=-1)//검사 후 돌 상태 -1로 돌려놓기.
        {
            timeVal=theTimingManager.CheckTiming();//가장 맞는 것 부터 0 1 2 3
            //if (TimingManager.noteAns == collision.hitCheck)
            if (AnsManager.CurrentAns == collision.hitCheck)
            {
                feedbackAnim();
                playScore += (10 - timeVal * 2);//점수를 더해서 넣어준다.
                Debug.Log("올바른 돌 : "+collision.hitCheck);
                Debug.Log("$$누적 점수$$ " + playScore);
            }
            else
            {//디버깅용
                Debug.Log("틀린 돌 "+collision.hitCheck+"정답은  "+AnsManager.CurrentAns);
            }
            collision.hitCheck = -1;//검사 완료 후 돌 상태 -1로 돌려놓기
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.Touch))
        {
            SceneManager.LoadScene("RealMain");
        }
    }

    void feedbackAnim()
    {
        judgePrefab[0].SetActive(false);//숨겼다가
        judgePrefab[1].SetActive(false);//숨겼다가
        judgePrefab[2].SetActive(false);//숨겼다가
        judgePrefab[3].SetActive(false);//숨겼다가
      //  judgePos[timeVal].transform.localPosition = effect_positions[TimingManager.noteAns];//옮기고
        judgePos[timeVal].transform.localPosition = effect_positions[AnsManager.CurrentAns];//옮기고
        //만약에 아래에 위치한 피드백이 너무 안보인다 싶으면 돌려주기. transform.localrotation
        /*if (AnsManager.CurrentAns < 8)
        {
            judgePrefab[timeVal].transform.localRotation = Quaternion.Euler(0.0f, -20f, 0.0f);
        }
        else{
            judgePrefab[timeVal].transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        */
        judgePrefab[timeVal].SetActive(true);//나타나기.
    }
}