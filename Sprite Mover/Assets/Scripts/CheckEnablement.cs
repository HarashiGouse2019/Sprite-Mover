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
        
                if (Input.GetKeyDown(KeyCode.P))
                
                    checkScriptStatus.enabled = !checkScriptStatus.enabled;
   
        //Doing this little bit right here should break the game!!!
        if (Input.GetKeyDown(KeyCode.Q))
           gameObject.SetActive(false);
      

    }
}
