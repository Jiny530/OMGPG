using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{

    string [] song_list = {"Free", "상사화", "Hedwig's Theme"};

    public static int selected_song, user_lev, user_ex, dic_lev, volume;
    public static int stone = -1;
    public static int frame = -1;
    public static int stick = -1;
    public static int[] bpms = {105,107,0};

    public static double usersyncDelay;
    public static double[] songDelay = {0,26.6,0};
    //public static int[][] answers = {{0,0,0,0,0,0},{7, 14, 12, 14, 12, 14, 12, 14, 7, 14, 12, 14, 7, 5, 7},{}};

    int[] top_score;

}
