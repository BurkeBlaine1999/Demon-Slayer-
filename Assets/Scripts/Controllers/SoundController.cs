using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    //=================================================================================
    //=================================== Variables ===================================
    //================================================================================= 

    [SerializeField] private AudioSource audioSrc;
    [SerializeField] private float musicVolume = 0.2f;

    //=================================================================================
    //=================================== Functions ===================================
    //================================================================================= 
	void Start () {

        // Assign Audio Source component to control it
        audioSrc = GetComponent<AudioSource>();
	}
	//======================

	void Update () {
        audioSrc.volume = musicVolume;
	}
    //======================
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}