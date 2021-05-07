using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicatorNow : MonoBehaviour
{
    public static int comingAns=16;
    
    private void OnTriggerEnter2D(Collider2D col)
    { 
        comingAns= col.GetComponent<Note>().ans;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        comingAns = 16;
    }
}