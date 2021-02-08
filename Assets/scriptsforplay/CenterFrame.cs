using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFrame : MonoBehaviour
{
    AudioSource myAudio;
    bool musicStart = false;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!musicStart)
        {
            if (collision.CompareTag("Note"))
            {
                myAudio.Play();//노트가 딱 지나갈 때 노래가 재생.
                musicStart = true;
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
