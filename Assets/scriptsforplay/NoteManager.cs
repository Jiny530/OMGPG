using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public float bpm = 0;
    double currentTime = 0d;
    public static int noteCnt;

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
            //이게!! 연주할 음을 다 연주하면!~!!! 이렇게 확인하는 함수! 만약에 노래 다 재생되면으로 종료 타이밍 잡기 어려워지면,,
            //여기에서! 노래 끄구~ result popup 하도록! 짜면 됩니다.
        }
        if (currentTime >= 180d / bpm)
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
