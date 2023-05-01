using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator Battling;
    bool TriggerBattle;
    void Start()
    {
        Battling = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TriggerBattle = playerMovement.TriggerBattle;
        
        if(TriggerBattle == true)
        {
            Battling.SetTrigger("Battling");
            playerMovement.TriggerBattle = false;
        }
    }
}
