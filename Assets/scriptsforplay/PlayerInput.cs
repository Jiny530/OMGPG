using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    TimingManager theTimingManager;
    public int timeVal;
    public static int playScore;//이 점수 값을 스테이지마다 저장하거나(챌언의 최고점수 기록용)
    //일정 점수를 기준으로 두고, ex. 토탈 노트 수가 정답 배열의 인덱스 크기(length)로 정해지니까 일정 퍼센트 맞을 경우 쪽지식을 포함하는 결과창으로 가거나
    //어느 정도 성취도인지를 알려주기 위해, 50퍼면 별 하나, 70 두개 90이상이면 세개 이런식으로 피드백을 주면 더 게임 구실이 살 듯.
    //그리고 그 별 갯수를 토탈 별에다가 더해서, 일정 별 개수마다 편경 디자인을 enable해준다는 식으로 가면 좋을듯

    private void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();
    }

    // ##########점수가 잘 되는지 디버깅 해봐야 함! 초안으로 짜둔 것
    void Update()
    {
        if (collision.hitCheck!=-1)//검사 후 돌 상태 -1로 돌려놓기.
        {
            timeVal=theTimingManager.CheckTiming();//가장 맞는 것 부터 0 1 2 3
            if (TimingManager.noteAns == collision.hitCheck)
            {
                playScore += (10 - timeVal * 2);//점수를 더해서 넣어준다.
                Debug.Log("올바른 돌 : "+collision.hitCheck);
                Debug.Log("$$누적 점수$$ " + playScore);
            }
            else
            {//디버깅용
                Debug.Log("틀린 돌 "+collision.hitCheck);

            }
            collision.hitCheck = -1;//검사 완료 후 돌 상태 -1로 돌려놓기
        }


        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.Touch))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
