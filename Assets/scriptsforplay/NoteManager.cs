using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteManager : MonoBehaviour
{
    public static int noteCnt;
    float bpm =Data.bpms[Data.selected_song];
    int hit_term = Data.hit_terms[Data.selected_song];
    bool playActive= true;
    double delay;

    public static double currentTime = Data.songDelay[Data.selected_song]+1.5d;

    [SerializeField] Transform tfNoteAppear = null; //노트가 생겨날 위치
    [SerializeField] GameObject goNote = null; 

    TimingManager theTimingManager;

    void Start()
    {
        theTimingManager = GetComponent<TimingManager>();
        SoundSystem.audios[Data.selected_song].Play();
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
                SceneManager.LoadScene("RealMain");
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
