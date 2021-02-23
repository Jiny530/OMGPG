using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* play scene의 playerInput과 동일한 역할, 대신 시간값을 측정하도록 수정  sync bpm은 105*/
public class SyncManager : MonoBehaviour
{
    TimingManager theTimingManager;
    double timeMid;
    double timer;
    double sum;
    //우리 곡을 정하면, 얼마 만큼의 시간 마다 타격을 해야하는지 값이 정해지잖아.
    //(노트의 생성 주기와 동일=180d / bpm) 이 간격과 동일하게 타격이 이루어져야 함.

    private void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();
    }

    // ##########디버깅 해봐야 함! 초안으로 짜둔 것
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("userTime "+timer);
            sum+=CenterFrame.center - timer;
        }

        if (NoteManager.noteCnt >= 15)
        {
            calSync();
            Debug.Log("sync값 " + timeMid);
            if (timeMid > 2)
            {
                //다시 하라고 하기.
            }
            else
            {
                //data에 있는 usersyncDelay에 반영하고 돌아가기
            }
        }
      /*  if (collision.hitCheck != -1)//검사 후 돌 상태 -1로 돌려놓기.
        {
            timeVal = theTimingManager.CheckTiming();//가장 맞는 것 부터 0 1 2 3
            if (TimingManager.noteAns == collision.hitCheck)
            {
                playScore += (10 - timeVal * 2);//점수를 더해서 넣어준다.
                Debug.Log("올바른 돌 : " + collision.hitCheck);
                Debug.Log("$$누적 점수$$ " + playScore);
            }
            else
            {//디버깅용
                Debug.Log("틀린 돌 " + collision.hitCheck);

            }
            collision.hitCheck = -1;//검사 완료 후 돌 상태 -1로 돌려놓기
        }


        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.Touch))
        {
            SceneManager.LoadScene("Main");
        }*/
    }
    void calSync()
    {
        timeMid = sum / 15;//sync에서 칠 노트의 수로 나눠주기
    }
}