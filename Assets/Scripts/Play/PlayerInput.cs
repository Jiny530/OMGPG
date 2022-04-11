using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public static Vector3[] effect_positions;
    [SerializeField] GameObject[] judgePrefab = null;//판정 이미지
    [SerializeField] GameObject[] judgePos=null;
    [SerializeField] GameObject Canvas=null;
    public ParticleSystem[] particles; // 파티클

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

  //  TimingManager theTimingManager;
    public int timeVal;
    public static int playScore;
    public static bool timer_init;

    private void Start()
    {
        playScore=0;
       // theTimingManager = FindObjectOfType<TimingManager>();
        set_effect_positions();
        timer_init=false;
    }

    void Update()
    {
        if (collision.hitCheck!=-1&&NoteManager.noteCnt>=1)//검사 후 돌 상태 -1로 돌려놓기.
        {
            timeVal=CheckTiming();//가장 맞는 것 부터 0 1 2 3
            //if (TimingManager.noteAns == collision.hitCheck)
            if (AnsManager.CurrentAns == collision.hitCheck)
            {
                feedbackAnim();
                playScore += (10 - timeVal * 2);//점수를 더해서 넣어준다.
                collision.hitCheck = -1;
            }
            else
                collision.hitCheck = -1;//검사 완료 후 돌 상태 -1로 돌려놓기
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.Touch))
        {
            SceneManager.LoadScene("RealMain");
        }
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.Touch)&&timer_init!=true){//타이머 이니셜라이즈 여기서
            Canvas.SetActive(false);
            SoundSystem.song_init();
            //NoteManager.currentTimeNote = Data.songDelays[Data.selected_song]+1.5f+ Data.usersyncDelay;
           // NoteManager.currentTimeSnare = Data.songDelays[Data.selected_song] + Data.snareDelays[Data.selected_song] + Data.usersyncDelay;
            timer_init=true;
        }
    }

    void feedbackAnim()
    {
        judgePrefab[0].SetActive(false);//숨겼다가
        judgePrefab[1].SetActive(false);//숨겼다가
        judgePrefab[2].SetActive(false);//숨겼다가
        judgePrefab[3].SetActive(false);//숨겼다가
        judgePos[timeVal].transform.localPosition = effect_positions[AnsManager.CurrentAns];//옮기고
        judgePrefab[timeVal].SetActive(true);//나타나기.

        //파티클 실행
       // particles[collision.hitCheck].Play();
    }

    public int CheckTiming()
    {
        //작은게 perfect, good cool bad 0123
        double interval=Math.Abs(Data.hit_tsample-Data.answers_tsample[Data.selected_song][NoteManager.noteCnt-1]);
        if(interval<=1000){
            return 0;
        }
        if(interval<=3000){
            return 1;
        }
        if(interval<=7000){
            return 2;
        }
        if(interval<=13000){
            return 3;
        }
        return 4;//miss
    }
}