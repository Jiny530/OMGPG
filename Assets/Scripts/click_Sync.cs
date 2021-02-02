using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class click_Sync : MonoBehaviour
{
  public void SceneChange()
  {
    SceneManager.LoadScene("Sync");
  }
}
