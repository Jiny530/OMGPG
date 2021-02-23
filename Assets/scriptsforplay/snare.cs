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
    double currentTime = NoteManager.currentTime;
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

    /*안쓰게 됐는데 혹시몰라서 남겨둠
    void snare_effect(string ans){ 
        // 태그에 맞는 편경의 자식프레임 활성화
        for (int i=0;i<16;i++){
            if (snares[i].transform.parent.gameObject.CompareTag(ans)){
                snares[i].SetActive(true); 
                // 활성화 되자마자 애니메이션 시작, 애니메이션 시작되고 끝까지 종료되면 false
                break;
            }
        }
    }*/

}
