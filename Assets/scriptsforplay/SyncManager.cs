using UnityEngine;
using UnityEngine.SceneManagement;

/* play scene의 playerInput과 동일한 역할, 대신 시간값을 측정하도록 수정  sync bpm은 105*/
public class SyncManager : MonoBehaviour
{
    TimingManager theTimingManager;
    double timeMid;
    double timer;
    double sum;
    double delay;
    [SerializeField] AudioSource beat = null;
    [SerializeField] GameObject setpop=null;
    [SerializeField] GameObject failpop=null;

    private void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();
    }

    void Update()
    {
        timer += Time.deltaTime;

       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("userTime "+timer);
            sum+=CenterFrame.center - timer;
        }*/

        if (NoteManager.noteCnt >= 8)
        {
            delay += Time.deltaTime;
            if (delay >= 4)
            {
                timeMid = sum / 8;
                if (timeMid > 3)
                {
                    Data.usersyncDelay = timeMid;
                    beat.Stop();
                    setpop.SetActive(true);
                }
                else
                {
                    beat.Stop();
                    failpop.SetActive(true);
                }
            }
        }
       if (collision.hitCheck != -1)
       {
            //Debug.Log("userTime " + timer);
            sum += CenterFrame.center - timer;
            collision.hitCheck = -1;//검사 완료 후 돌 상태 -1로 돌려놓기
       }

       if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.Touch))
       {
            SceneManager.LoadScene("RealMain");
       }
    }
}