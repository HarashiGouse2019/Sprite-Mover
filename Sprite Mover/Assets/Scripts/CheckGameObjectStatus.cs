///Checking if the Player GameObject is active or not
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameObjectStatus : MonoBehaviour
{
    public GameObject Player; //In the editor, you can select whatever is the player to be assigned to this variable

    void Update()
    {
        switch (Player.activeInHierarchy) //Dev Note: I'm in love with the switch statement
        {

            case false:
                Debug.Log("We see that you're Player GameObject is inactive. Press \'Q\' again to make it active"); //Let's me know if the player
                                                                                                                    //is inactive. You can switch the player
                                                                                                                    //activity back on however.
                if (Input.GetKeyDown(KeyCode.Q))     
                /*{*/Player.SetActive(true);/*}*/
            break;
            //-------------------------------------------------------------------------------------------------------------
            case true:
                Debug.Log("Whatever you do, don't press \'Q\'");
            break;

        }


        
    }
}
