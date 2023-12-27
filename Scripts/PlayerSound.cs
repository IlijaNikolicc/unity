using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSourceWalking;
    [SerializeField]
    private AudioSource audioSourceRunning;

    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) 
        {
            
            if(Input.GetKey(KeyCode.LeftShift))
            {
                audioSourceRunning.enabled = true;
                audioSourceWalking.enabled = true;
            }
            else
            {
                audioSourceWalking.enabled = true;
                audioSourceRunning.enabled = false;
            }

        }
        else
        {
            audioSourceWalking.enabled = false;
            audioSourceRunning.enabled = false;
        }
    }
}
