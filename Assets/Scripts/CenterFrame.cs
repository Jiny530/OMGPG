using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFrame : MonoBehaviour
{
    double nowTime = 0;
    double enterT;
    public static double center;
    bool musicStart;
    [SerializeField] AudioSource myAudio;

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
            center = (nowTime + enterT)/2;
        }
    }
}
