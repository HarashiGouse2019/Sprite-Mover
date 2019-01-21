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
            Application.Quit();

            //This was to ensure that the script executed successfully.
            Debug.Log("If you get this message, the \"Application.Quit\" function executed successfully!");

            //At first I though having a Debug.Log wouldn't do anything, but it just helped me confirm
            //That it wasn't working after I built it. This is a handy way to really see if Application.Quit work,
            //Though I am no professional.
        }
    }

}
