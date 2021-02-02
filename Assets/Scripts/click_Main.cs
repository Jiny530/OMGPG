using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class click_Main : MonoBehaviour
{
  public void SceneChange()
  {
    SceneManager.LoadScene("Main");
  }
}
