using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmp_floatingSheet : MonoBehaviour
{
    public float speed = 0.4f;//speed of the text(song)

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed, 0, 0);
        if (transform.localPosition.x < -670)
        {
            speed = 0;
            //transform.localPosition = new Vector3(250,0, 0);
        }
    }
}
