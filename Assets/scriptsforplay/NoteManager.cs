using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NoteManager : MonoBehaviour
{
    //indicator를 위한 변수
    public GameObject right;
    public GameObject left;
    public Transform head;

    //노트 생성을 위한 변수
    public static int noteCnt;
   // float bpm =Data.bpms[Data.selected_song];
    int hit_term = Data.hit_terms[Data.selected_song];
   // public static double currentTimeNote;
   // public static double currentTimeSnare;
  //  [SerializeField] Transform tfNoteAppear = null; //노트가 생겨날 위치
  //  [SerializeField] GameObject goNote = null;
   // TimingManager theTimingManager;

    //노래가 끝나면 팝업을 띄우기 위햔 변수
    bool playActive= true;
    double delay;//마지막에 팝업 뜨기 전에 딜레이 주려고 만든 변수
    public static bool finished;

    //올가미 생성을 위한 변수
    [SerializeField] public GameObject[] snares;
    int num = 0; //현재 정답 순서

double sampleT;
    void Start()
    {
        sampleT=0;
        finished=false;
       // theTimingManager = GetComponent<TimingManager>();
        noteCnt=0;//로드시마다 초기화.
        num=0;
    }

    void Update()
    {
        

        if(PlayerInput.timer_init==true){

            //currentTimeNote += Time.deltaTime;
           // currentTimeSnare += Time.deltaTime;

            if (noteCnt >= Data.answers[Data.selected_song].Length){
                delay +=Time.deltaTime;
                playActive = false;
            
                if (delay>=6){
                    finished=true;
                    SceneManager.LoadScene("Ranking");
                }
            }

            //if (currentTimeSnare >= 60d*hit_term / bpm && num < Data.answers[Data.selected_song].Length){
            if ((Data.answers_tsample[Data.selected_song][num]-SoundSystem.bgm.timeSamples)<88199 && num < Data.answers[Data.selected_song].Length){
            // 다음 비트 나올 간격이 지나면 다음올가미도 활성화
            //snare_effect(Note.tmpAns[num]);
                snares[Data.answers[Data.selected_song][num]].SetActive(true); 
                //currentTimeSnare -= 60d*hit_term / bpm;
                num++;
            }
            //if((AnsManager.CurrentAns>=12||AnsManager.CurrentAns<=3)&&AnsManager.CurrentAns!=16)
               // indicatorL();
           // else if(AnsManager.CurrentAns!=16)
               // indicatorR();
           // else
           //     indicatorOff();
        }
    }


    public void indicatorL(){
        if(head.localRotation.y<-0.1){//왼쪽으로 가야 할 때
            right.SetActive(true);
        }
        else
            right.SetActive(false);   
    }
    public void indicatorR(){
        if(head.transform.localRotation.y>0.1){//오른쪽으로 가야 할 때
            left.SetActive(true);
        }
        else
            left.SetActive(false);
    }
    public void indicatorOff(){
        left.SetActive(false);
        right.SetActive(false);
    }
}