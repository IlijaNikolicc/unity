using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Timer timerScript;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Igrac") && QuizActivator.counter >= 6)
        {
            timerScript.Finnished();
            Debug.Log(Time.time);
            //pristupi vremenu sa scoreboard OVDE!
        }
    }

}
