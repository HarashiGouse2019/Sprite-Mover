//A script used to quit the game.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeKey : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); //Close out of the application

        }
    }

}
