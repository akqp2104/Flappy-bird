using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Background music
public class Music : MonoBehaviour
{
    private AudioSource music;

    private void Start()
    {
        music = GetComponent<AudioSource>();
        music.Play();
    }
}
