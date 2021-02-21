using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFrame : MonoBehaviour
{
    // Start is called before the first frame update
    double nowTime = 0;
    double enterT;
   
    private void Update()
    {
        nowTime += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
         
            //Debug.Log("ENTER "+nowTime);
            enterT = nowTime;
        }   
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            //Debug.Log("EXIT " + nowTime);
            Debug.Log(nowTime - enterT);
            Debug.Log("지금 답 "+ collision.GetComponent<Note>().ans);
        }
    }
}
