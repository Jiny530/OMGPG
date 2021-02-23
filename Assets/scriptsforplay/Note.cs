using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400;
    public static int[] ansPlay = Data.answers[Data.selected_song];
    public int ans; 
    UnityEngine.UI.Image noteImage;

    private void Start()
    {
        ans = ansPlay[NoteManager.noteCnt-1];
        noteImage = GetComponent<UnityEngine.UI.Image>();
    }

    public void HideNote()
    {
        noteImage.enabled = false;
    }

    void Update()
    {
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;//꼭 로컬 하기
    }
}
