using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation2 : MonoBehaviour
{
    Animator Battled;
    bool EndBattle;
    void Start()
    {
        Battled = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EndBattle = mousePosition.EndBattle;
        if(EndBattle == true)
        {
            Battled.SetTrigger("Battled");
            mousePosition.EndBattle = false;
        }
    }
}
