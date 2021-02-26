using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public static Vector3[] effect_positions;
    [SerializeField] GameObject[] judgePrefab = null;//판정 이미지

    TimingManager theTimingManager;
    public int timeVal;
    public static int playScore;//이 점수 값을 스테이지마다 저장하거나(챌언의 최고점수 기록용)
   

    //일정 점수를 기준으로 두고, ex. 토탈 노트 수가 정답 배열의 인덱스 크기(length)로 정해지니까 일정 퍼센트 맞을 경우 쪽지식을 포함하는 결과창으로 가거나
    //어느 정도 성취도인지를 알려주기 위해, 50퍼면 별 하나, 70 두개 90이상이면 세개 이런식으로 피드백을 주면 더 게임 구실이 살 듯.
    //그리고 그 별 갯수를 토탈 별에다가 더해서, 일정 별 개수마다 편경 디자인을 enable해준다는 식으로 가면 좋을듯

    private void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();
        set_effect_positions();
    }

    void Update()
    {
        judgePrefab[0].transform.position = effect_positions[1];
        judgePrefab[1].transform.position = effect_positions[5];
        judgePrefab[2].transform.position = effect_positions[10];
        judgePrefab[3].transform.position = effect_positions[7];

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
                Debug.Log("틀린 돌 "+collision.hitCheck+"정답은  "+TimingManager.noteAns);
            }
            collision.hitCheck = -1;//검사 완료 후 돌 상태 -1로 돌려놓기
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.Touch))
        {
            SceneManager.LoadScene("RealMain");
        }
    }

    void set_effect_positions()
    {
        effect_positions[0] = new Vector3(-1.131f, 0.154f, 0f) ;
        effect_positions[1] = new Vector3(-0.827f, 0.154f, 0f);
        effect_positions[2] = new Vector3(-0.463f, 0.154f, 0f);
        effect_positions[3] = new Vector3(-0.16f, 0.154f, 0f);
        effect_positions[4] = new Vector3(0.148f, 0.154f, 0f);
        effect_positions[5] = new Vector3(0.433f, 0.154f, 0f);
        effect_positions[6] = new Vector3(0.827f, 0.154f, 0f);
        effect_positions[7] = new Vector3(1.132f, 0.154f, 0f);

        effect_positions[8] = new Vector3(1.131f, -0.541f, 0f);
        effect_positions[9] = new Vector3(-0.827f, -0.541f, 0f);
        effect_positions[10] = new Vector3(-0.463f, -0.541f, 0f);
        effect_positions[11] = new Vector3(-0.16f, -0.541f, 0f);
        effect_positions[12] = new Vector3(-0.148f, -0.541f, 0f);
        effect_positions[13] = new Vector3(0.433f, -0.541f, 0f);
        effect_positions[14] = new Vector3(0.807f, -0.541f, 0f);
        effect_positions[15] = new Vector3(-1.132f, -0.541f, 0f); 
    }

}
    //  {new Vector3(-1.131,0.154,0 },new Vector3( -0.827,0.154,0),new Vector3( -0.463,0.154,0 ),new Vector3(-0.16,0.154,0 ),new Vector3(0.148,0.154,0 ),new Vector3(0.433,0.154,0 ),new Vector3(0.827,0.154,0 ),new Vector3(1.132,0.154,0 ),
    //   new Vector3(1.131,-0.541,0 ),new Vector3(-0.827,-0.541,0 ),new Vector3(-0.463,-0.541,0 ),new Vector3(-0.16,,-0.541,0 ),new Vector3(-0.148,-0.541,0 ),new Vector3(0.433,-0.541,0 ),new Vector3(0.807,-0.541,0 ),new Vector3(-1.132,-0.541,0 ) };


