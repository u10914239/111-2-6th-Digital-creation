using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    AudioSource Paper;
    void Start()
    {
        Paper = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    public void Play_sound()
    {
        Paper.Play();
    }
}
