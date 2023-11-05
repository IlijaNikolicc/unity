using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Timer timerScript;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Igrac"))
        {
            timerScript.Finnished();
            Debug.Log(Time.time);
            //pristupi vremenu sa scoreboard OVDE!
        }
    }

}
