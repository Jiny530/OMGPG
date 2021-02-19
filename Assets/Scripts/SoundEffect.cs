using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{

    private AudioSource theAudio;

    [SerializeField] private AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        theAudio = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySE() {
        theAudio.Play();
    }
}
