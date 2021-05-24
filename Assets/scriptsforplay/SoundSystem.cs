using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] AudioSource[] bgms = null;
    [SerializeField] AudioSource[] pgMusics = null;

    public static AudioSource pgMusic;
    public static AudioSource bgm;
    public static double note_term;

    void Start(){
        Debug.Log(Data.selected_song);
        pgMusic=pgMusics[Data.selected_song];
        
        bgm=bgms[Data.selected_song];
        pgMusic.volume = Data.volumes[0];
        bgm.volume = Data.volumes[1];
        note_term=Data.note_terms[Data.selected_song];
    }
    public static void song_init()
    {
        pgMusic.Play(0);
        bgm.Play(0);
    }

    void Update(){
        if(PlayerInput.timer_init==true){
            bgm.timeSamples=pgMusic.timeSamples;
        }
        if(Data.answers_tsample[Data.selected_song][NoteManager.noteCnt]-bgm.timeSamples<=note_term&& NoteManager.noteCnt < Data.answers[Data.selected_song].Length){
            NoteManager.noteCnt++;
            AnsManager.CurrentAns=Data.answers[Data.selected_song][NoteManager.noteCnt-1];
            //Debug.Log("updated ans : "+Data.answers[Data.selected_song][NoteManager.noteCnt-1]);
        }
    }
}
