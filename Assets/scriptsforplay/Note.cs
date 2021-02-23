using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400;
    //public static string[] strAns = { "pg7", "pg14", "pg12", "pg14", "pg12", "pg14", "pg12", "pg14", "pg7", "pg14", "pg12", "pg14", "pg7", "pg5", "pg7" };//상사화
    public static int[] tmpAns = { 7, 14, 12, 14, 12, 14, 12, 14, 7, 14, 12, 14, 7, 5, 7 };//상사화
    public int ans; 
    UnityEngine.UI.Image noteImage;

    private void Start()
    {
        ans = tmpAns[NoteManager.noteCnt-1];
        noteImage = GetComponent<UnityEngine.UI.Image>();
    }
    public void HideNote()
    {
        noteImage.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;//꼭 로컬 하기
    }
}
