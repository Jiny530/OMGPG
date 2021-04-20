using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col : MonoBehaviour
{
    public AudioSource sound;
    float m_countToStop;
    public GameObject sync_snare;
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_countToStop >= 0f)
        {
            m_countToStop -= Time.deltaTime;
            if (m_countToStop <= 0f)
            {
                StopVibration();
            }
        }
        
    }

    public void OnCollisionEnter(Collision col){
        if (sync_snare.activeSelf) {
            sync_snare.SetActive(false);
            particles.Play();
        }
        else sync_snare.SetActive(true);
        sound.PlayOneShot(sound.clip);
        Vibrate(50f);
    }

    void Vibrate(float ms)
    {
        OVRInput.SetControllerVibration(0.4f, 0.4f, OVRInput.Controller.RTouch);
        m_countToStop = (ms) / 1000;
    }
    void StopVibration()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        m_countToStop = 0;
    }
}
