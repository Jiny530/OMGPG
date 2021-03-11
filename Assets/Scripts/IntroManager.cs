using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
 
public class IntroManager : MonoBehaviour
{
// can ignore the update, it's just to make the coroutines get called for example

    int flag = 0;
    [SerializeField] Text text1 = null;
    [SerializeField] Text text2 = null;

    void Start(){
        StartCoroutine(FadeTextToFullAlpha(1.5f, text1, text2));
    }

    void Update()
    {
    }
 
    public IEnumerator FadeTextToFullAlpha(float t, Text i, Text j)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }

         j.color = new Color(j.color.r, j.color.g, j.color.b, 0);
        while (j.color.a < 1.0f)
        {
            j.color = new Color(j.color.r, j.color.g, j.color.b, j.color.a + (Time.deltaTime / t));
            yield return null;
        }
        j.color = new Color(j.color.r, j.color.g, j.color.b, 1);
        while (j.color.a > 0.0f)
        {
            j.color = new Color(j.color.r, j.color.g, j.color.b, j.color.a - (Time.deltaTime / t));
            yield return null;
        }

        SceneManager.LoadScene("RealMain");
    }
 
}