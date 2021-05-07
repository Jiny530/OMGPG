using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();//생성된 노트들을 리스트에 담아서 잘 범위에 있는지 판단할 것임
 //   public static int noteAns=-3;
    [SerializeField] Transform Center = null; //판정 한 가운데
    [SerializeField] RectTransform[] timingRect = null; //판정 범위
    Vector2[] timingBoxs = null;//rect transform 값 담기


    private void Start()
    {
        timingBoxs = new Vector2[timingRect.Length];//정해놓은 사이즈
        for(int i = 0; i < timingRect.Length; i++)//사이즈만큼 돌면서 리스트 채우기
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2, 
                              Center.localPosition.x + timingRect[i].rect.width / 2);//하나의 판정 범위 0이 제일 좁고, bad로 갈 수록 범위 커짐
        }
        Debug.Log("1 "+timingBoxs[0]);
        Debug.Log("2 "+timingBoxs[1]);
        Debug.Log("3 "+timingBoxs[2]);
        Debug.Log("4 "+timingBoxs[3]);
    }

    public int CheckTiming()
    {
        
        for(int i=0; i < boxNoteList.Count; i++)//각각 판정 단계 만큼 반복문
        {
            Debug.Log("rect "+boxNoteList[i].transform.localPosition.x);
            float t_notePosX = boxNoteList[i].transform.localPosition.x;
            for(int x = 0; x < timingBoxs.Length; x++)//노트만큼
            {
                if(timingBoxs[x].x<=t_notePosX && t_notePosX<=timingBoxs[x].y)//범위에 들어왔누ㅡㄴ지..
                {
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);
                    return x;
                }
            }
        }
        return 4;//miss
    }
}