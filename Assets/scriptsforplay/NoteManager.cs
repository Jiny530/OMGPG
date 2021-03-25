using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NoteManager : MonoBehaviour
{
    public static bool finished;
    int num = 0; //현재 정답 순서

    public GameObject right;
    public GameObject left;
    public Transform head;

    public static int noteCnt;
    float bpm =Data.bpms[Data.selected_song];
    int hit_term = Data.hit_terms[Data.selected_song];

    bool playActive= true;
    double delay;//마지막에 팝업 뜨기 전에 딜레이 주려고 만든 변수

    public static double currentTimeNote;
    public static double currentTimeSnare;

    [SerializeField] public GameObject[] snares;

    [SerializeField] Transform tfNoteAppear = null; //노트가 생겨날 위치
    [SerializeField] GameObject goNote = null;
    TimingManager theTimingManager;

    void Start()
    {
        theTimingManager = GetComponent<TimingManager>();
        currentTimeNote = Data.songDelays[Data.selected_song]+1.5f+ Data.usersyncDelay;
        currentTimeSnare = Data.songDelays[Data.selected_song] + Data.snareDelays[Data.selected_song] + Data.usersyncDelay;
        noteCnt=0;//로드시마다 초기화.
        num=0;
    }

    void Update()
    {
        currentTimeNote += Time.deltaTime;
        currentTimeSnare += Time.deltaTime;
        if (noteCnt >= Data.answers[Data.selected_song].Length)
        {//음악 종료 시 - 팝업이 뜨도록
            delay +=Time.deltaTime;
            playActive = false;
            //팝업 엑티브
            if (delay>=4)
            {
                finished=true;
            }
        }
        if (currentTimeNote >= 60d*hit_term / bpm&&playActive)
        {//다음 비트가 나올 차례가 되면
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);//노트를 등장 시키기
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
            currentTimeNote -= 60d*hit_term / bpm;//오차가 쬐끔 생기기 때문에... 게임은 프레임 타임이어서,... 그거 챙기려고..0으로 초기화x 쌓이면 점점 밀림
            noteCnt++;
        }
        if (currentTimeSnare >= 60d*hit_term / bpm && num < Data.answers[Data.selected_song].Length)
        {//dhf
            // 다음 비트 나올 간격이 지나면 다음올가미도 활성화
            //snare_effect(Note.tmpAns[num]);
            snares[Data.answers[Data.selected_song][num]].SetActive(true); //이 라인에서 "IndexOutOfRangeException: Index was outside the bounds of the array." 이런 에러 남. 근데 작동은 정상적이긴 해.
            currentTimeSnare -= 60d*hit_term / bpm;
            num++;
 
        }//혜진아 num이랑 noteCnt이게 같은 뜻인데 ++타이밍이 서로 달라서,, 음음~ 뭐가먼저 나오는지 생각해서 ++이 중복으로 들어가지 않되, 하나로 합칠 수 있음 좋을 것 같아. 아님 말구
        if((indicatorNow.comingAns>=12||indicatorNow.comingAns<=3)&&indicatorNow.comingAns!=16)
            indicatorR();
        else if(indicatorNow.comingAns!=16)
            indicatorL();
        else
            indicatorOff();
    }

    private void OnTriggerExit2D(Collider2D collision)//노트가 파괴되도록 하기 위해서
    {
        if (collision.CompareTag("Note")){
            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

    public void indicatorL(){
        if(head.localRotation.y>0.1){//왼쪽으로 가야 할 때
            right.SetActive(true);
        }
        else
            right.SetActive(false);   
    }
    public void indicatorR(){
        if(head.transform.localRotation.y<-0.1){//오른쪽으로 가야 할 때
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
