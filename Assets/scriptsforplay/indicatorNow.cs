using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicatorNow : MonoBehaviour
{
    public static int comingAns=16;
    
    private void OnTriggerEnter2D(Collider2D col)
    { 
        comingAns= col.GetComponent<Note>().ans;
        Debug.Log("현재타임 값- ans start 충돌"+NoteManager.poison_timer);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        comingAns = 16;
        Debug.Log("현재타임 값- ans end 종료"+NoteManager.poison_timer);
    }
}
