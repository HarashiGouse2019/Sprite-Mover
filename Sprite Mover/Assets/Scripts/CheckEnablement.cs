using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnablement : MonoBehaviour
{

    public GameObject Player;

    private Movement checkScriptStatus;
    

    void Awake()
    {
       checkScriptStatus = GetComponent<Movement>();
    }
    void Update()
    {
        //Checks if the Script and Rigidbody2D components on the GameObject has been enabled
        switch (checkScriptStatus.enabled)
        {
            case false:
                Debug.Log("Your script in which handles movements seems to be disabled. Press \'P\' to enable.");
                if (Input.GetKeyDown(KeyCode.P))
                {
                    checkScriptStatus.enabled = !checkScriptStatus.enabled;
                }
                break;
        }

        //Doing this little bit right here should break the game!!!
        if (Input.GetKeyDown(KeyCode.Q))
           gameObject.SetActive(false);
      

    }
}
