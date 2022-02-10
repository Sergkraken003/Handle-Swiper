using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonControll : MonoBehaviour
{
  public string action;
  void OnMouseUpAsButton()
  {
      switch (action)
      {
        case "Play":
            SceneManager.LoadScene("Game Scene");
            break;
      }
      }
}