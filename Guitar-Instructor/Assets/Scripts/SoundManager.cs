using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    static AudioSource audioSource;

    public enum Chord
    {
        A,
        C,
        G,
        D,
        E
    }

    [System.Serializable]
    public class ChordAudioClip
    {
        public SoundManager.Chord chord;
        public AudioClip audioClip;
    }

    public static void PlayChordSound(Chord chord)
    {
        GameObject soundGameObject = new GameObject("Sound");
        audioSource = soundGameObject.AddComponent<AudioSource>();
        AudioClip audioClip = GetAudioClip(chord); 
        audioSource.PlayOneShot(audioClip);
        UnityEngine.Object.Destroy(soundGameObject, audioClip.length);
    }

    public static bool IsPLaying()
    {
        if(audioSource)
            return audioSource.isPlaying;
        return false;
    }

    private static AudioClip GetAudioClip(Chord chord)
    {
        foreach (ChordAudioClip item in GameManager.Instance.chordAudioClips)
        {
            if(item.chord == chord)
            {
                return item.audioClip;
            }
        }
        Debug.Log("AudioClip is missing!");
        return null;
    }
}
