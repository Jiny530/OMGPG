using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnsManager : MonoBehaviour
{
    public static int CurrentAns=16;
    
    private void OnTriggerEnter2D(Collider2D col)
    { 
        //TimingManager.noteAns=col.GetComponent<Note>().ans;
        CurrentAns = col.GetComponent<Note>().ans;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        //TimingManager.noteAns=16;
        CurrentAns = 16;

    }
}
//콜라이더로하지않고 할 수 있는 방법:
/*생성되는 간격= BPM 한 번 생기고 나면 지나가는 속도는 동일, 그러면 생성 후 어느 지점을 지나가는
시점은 동일하다. initiate 할 때 타이머를 먼저, set하고 특정 지점까지 가는 시간을 측정해서
그 시간값으로 넣어준다.*/