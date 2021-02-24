using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NoteManager : MonoBehaviour
{
    public static bool finished;

    public static int noteCnt;
    float bpm =Data.bpms[Data.selected_song];
    int hit_term = Data.hit_terms[Data.selected_song];


    bool playActive= true;
    double delay;//마지막에 팝업 뜨기 전에 딜레이 주려고 만든 변수

  

    public static double currentTime = Data.songDelays[Data.selected_song]+1.5d;

    [SerializeField] Transform tfNoteAppear = null; //노트가 생겨날 위치
    [SerializeField] GameObject goNote = null;
    

    TimingManager theTimingManager;

    void Start()
    {
        theTimingManager = GetComponent<TimingManager>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (noteCnt >= Data.answers[Data.selected_song].Length)
        {
            delay +=Time.deltaTime;
            playActive = false;
            //팝업 엑티브
            if (delay>=4)
            {
                finished = true;//이후 resultManager에서 결과화면 출력. 노래 끄는건 여기서 해야할지도?
            }
        }
        if (currentTime >= 60d*hit_term / bpm&&playActive)
        {//다음 비트가 나올 차례가 되면
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);//노트를 등장 시키기
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
            currentTime -= 60d*hit_term / bpm;//오차가 쬐끔 생기기 때문에... 게임은 프레임 타임이어서,... 그거 챙기려고..0으로 초기화x 쌓이면 점점 밀림
            noteCnt++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)//노트가 파괴되도록 하기 위해서
    {
        if (collision.CompareTag("Note")){
            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
