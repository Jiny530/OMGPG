using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coll : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision col)
    {
        print("닿았다");
    }
}