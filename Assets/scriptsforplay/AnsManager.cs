using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnsManager : MonoBehaviour
{
    public static int CurrentAns=16;
    
    private void OnTriggerEnter2D(Collider2D col)
    { 
        //TimingManager.noteAns=col.GetComponent<Note>().ans;
        CurrentAns= col.GetComponent<Note>().ans;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        //TimingManager.noteAns=16;
        CurrentAns = 16;
    }
}
