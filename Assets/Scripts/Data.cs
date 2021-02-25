using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    string[] song_list = {"Free", "상사화", "Hedwig's Theme" };
    public static int[] bpms = { 0, 105, 107, 0 };
    public static double[] songDelays = { 0, -15.0, 0 };
    public static int[] hit_terms = { 4, 3, 3 };
    public static int[][] answers = new[]
    {
        new[] {0,0,0,0,0,0,0,0},//sync
        new[] {7, 14, 12, 14, 12, 14, 12, 14, 7, 14, 12, 14, 7, 5, 7},//상사화
        new[] {5, 5, 10, 7, 5, 4, 12, 5, 5, 15, 13, 13, 11, 5, 12, 12, 13, 11, 8, 11, 12, 12, 12, 15, 13, 11, 5}//해리포터
    };

    public static int[] best_scores = { 0, 0, 0 };
    public static int[] max_scores = { 0, 150, 270 };

    public static bool[] acquired_stone= { false, false, false, false, false };
    public static bool[] acquired_frame = { false, false, false, false, false };
    public static bool[] acquired_stick = { false,false,false};
    public static bool[] acquired_info = { false,false,false};

    public static int[] reward_index = { 0,0,0,0};//인덱스 순서는 곡 순서와 동일
    public static int[] reward_type = {-1,3,1,2};//0 frame, 1 stone, 2 stick, 3 info

    public static int selected_song=1, user_lev, user_ex, dic_lev, volume;
    public static double usersyncDelay;
    public static int stone = -1;
    public static int frame = -1;
    public static int stick = -1;
}
