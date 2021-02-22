using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteManager : MonoBehaviour
{
    public float bpm = 0;
    public static int noteCnt;
    bool playActive= true;
    int delay;

    static double songDelay = -26.6d;//상사화 기준 딜레이..(25.6)-> data에 각 곡 전주 길이 저장해놓고 가져와야 함(선택된 곡에 맞게)
    static double moveDelay = 1.5d;//일정값.
    double currentTime = songDelay + moveDelay;
  //  double currentTime = 0;


    [SerializeField] Transform tfNoteAppear = null; //노트가 생겨날 위치
    [SerializeField] GameObject goNote = null; // close 버튼을 누르면 true;

    TimingManager theTimingManager;

    void Start()
    {
        theTimingManager = GetComponent<TimingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        currentTime += Time.deltaTime;//1초씩 증가
        if (noteCnt >= Note.tmpAns.Length)
        {
            delay++;
            playActive = false;
            Debug.Log("false 되었는데여...ㅜ");
            SceneManager.LoadScene("Main");
            //팝업 엑티브
            if (delay>=4)//조금 더 기다려줘야 하잖아,.. 그래서 조금 딜레이를 추가해봄.. 검은 바 끝까지 가는 시간 3초.(측정값)
            {
                SceneManager.LoadScene("RealMain");//일단은 종료되도록 함...->팝업을 새로운 신으로 팔지, 플레이 신에 유아이를 새로 파서 눈앞에 붙일지 고민!
            }
        }
        if (currentTime >= 180d / bpm&&playActive)
        {//다음 비트가 나올 차례가 되면
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);//노트를 등장 시키기
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
            currentTime -= 180d / bpm;//오차가 쬐끔 생기기 때문에... 게임은 프레임 타임이어서,... 그거 챙기려고..0으로 초기화x 쌓이면 점점 밀림

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
