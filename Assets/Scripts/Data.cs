using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{

    string [] song_list = {"Birthday", "DDU-DU-DDU-DU", "Shape Of you"};

    public static int selected_song, user_lev, user_ex, dic_lev, volume;
    public static int stone = -1;
    public static int frame = -1;
    public static int stick = -1;

    float sink;

    int[] top_score;

}
