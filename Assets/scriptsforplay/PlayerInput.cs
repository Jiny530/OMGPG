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
    public static int playScore;
   

    private void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();

    }

    void Update()
    {
        if (collision.hitCheck!=-1)//검사 후 돌 상태 -1로 돌려놓기.
        {
            timeVal=theTimingManager.CheckTiming();//가장 맞는 것 부터 0 1 2 3
            if (TimingManager.noteAns == collision.hitCheck)
            {
                feedbackAnim();
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

    void feedbackAnim()
    {
        judgePrefab[0].SetActive(false);//숨겼다가
        judgePrefab[1].SetActive(false);//숨겼다가
        judgePrefab[2].SetActive(false);//숨겼다가
        judgePrefab[3].SetActive(false);//숨겼다가
        judgePrefab[timeVal].transform.position = effect_positions[TimingManager.noteAns];//옮기고
        judgePrefab[timeVal].SetActive(true);//나타나기.
    }

   

}