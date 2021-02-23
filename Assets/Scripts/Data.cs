using UnityEngine;

public class Data : MonoBehaviour
{
    string[] song_list = {"!EMPTY!","Free", "상사화", "Hedwig's Theme" };//0번은 빈 인덱스, 디폴트 시 index오류 피하기 위함.
    public static int[] bpms = { 0, 105, 107, 0 };
    public static double[] songDelay = { 0, 0, -15.0, 0 };
    public static int[] hit_terms = { 0, 4, 3, 3 };
    public static int[][] answers = new[]
    {
        new[] {0},
        new[] {0,0,0,0,0,0,0,0},//sync
        new[] {7, 14, 12, 14, 12, 14, 12, 14, 7, 14, 12, 14, 7, 5, 7},//상사화
        new[] {5, 5, 10, 7, 5, 4, 12, 5, 5, 15, 13, 13, 11, 5, 12, 12, 13, 11, 8, 11, 12, 12, 12, 15, 13, 11, 5}//해리포터
    };

    public int[] top_score = new int[4];

    public static int selected_song, user_lev, user_ex, dic_lev, volume;
    public static double usersyncDelay;
    public static int stone = -1;
    public static int frame = -1;
    public static int stick = -1;
}
