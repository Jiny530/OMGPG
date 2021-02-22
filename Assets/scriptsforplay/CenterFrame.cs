using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFrame : MonoBehaviour
{
    // Start is called before the first frame update
    double nowTime = 0;
    double enterT;
    bool musicStart;
    AudioSource myAudio;
    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        nowTime += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag("Note"))
        {
            if (!musicStart)
            {
                myAudio.Play();
                musicStart = true; 
            }
            Debug.Log("ENTER "+nowTime);
            enterT = nowTime;
        }   
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            //Debug.Log("EXIT " + nowTime);
            //Debug.Log(nowTime - enterT);
        }
    }
}
