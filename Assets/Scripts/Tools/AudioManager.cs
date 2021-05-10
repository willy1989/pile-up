using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip StackSound;

    public AudioClip PerfectlyStackSound;

    public AudioClip GrowCubeSound;

    public AudioClip NewRecordSound;

    [SerializeField] AudioSource audioSource;


    public void PlaySoundEffect(AudioClip clip)
    {
        audioSource.clip = clip;

        audioSource.Play();
    }

}
