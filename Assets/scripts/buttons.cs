using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{

   // void Update()
  //  {
  //      if (Input.GetKeyDown(AButton) || Input.GetKeyDown(BButton))
 //           SceneManager.LoadScene("title");
    //}

    public void exit()
    {
        SceneManager.LoadScene("gmae");
    }

    public void actualyexit()
    {
        Application.Quit();
    }


}
