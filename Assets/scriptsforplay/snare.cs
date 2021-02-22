using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class snare : MonoBehaviour
{
    // 편경 정답지에 맞춰 생성
    // 전체적으로 노트매니저와 같이가도 좋을거같음.

    public GameObject[] snares;
    double currentTime = NoteManager.currentTime + 2; //곡 시작보다 2초 빨리 올가미 나오게 하려고. 근데 시간 좀 이상한듯
    int num = 0; //현재 정답 순서
    public float bpm = 107;
    public bool start_sign = true;

    public void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= 0 && start_sign)
        {
            snares[Note.tmpAns[num]].SetActive(true);  
            num++;
            start_sign = false;
        }
        if (currentTime >= 180d / bpm && num < Note.tmpAns.Length)
        {
            // 다음 비트 나올 간격이 지나면 다음올가미도 활성화
            //snare_effect(Note.tmpAns[num]);
            snares[Note.tmpAns[num]].SetActive(true); 
            currentTime -= 180d / bpm;
            num++;
        }
    }

}
