using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    string [] song_list = {"Free", "상사화", "Hedwig's Theme"};
    public static int[] bpms = { 105, 107, 0 };
    public static double[] songDelay = {0,15.0,0};
    int[][] answers = new[]
        {
            new[] {0,0,0,0,0,0},//sync
            new[] {7, 14, 12, 14, 12, 14, 12, 14, 7, 14, 12, 14, 7, 5, 7},//상사화
            new[] { 1, 2 }//해리포터
        };

    public static int selected_song=-1, user_lev, user_ex, dic_lev, volume;
    public static int stone = -1;
    public static int frame = -1;
    public static int stick = -1;
    public static double usersyncDelay;
    int[] top_score= { 0, 0, 0 };

}
