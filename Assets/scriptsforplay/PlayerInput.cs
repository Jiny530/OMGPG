using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    TimingManager theTimingManager;
    public int timeVal;
    public int stoneVal;
    private void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collision.hitCheck!=-1)//검사 후 돌 상태 -1로 돌려놓기.
        {
            timeVal=theTimingManager.CheckTiming();
            if (TimingManager.noteAns == collision.hitCheck)
            {
                //점수를 더해서 넣어준다.
                Debug.Log("올바른 돌 : "+collision.hitCheck);
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
