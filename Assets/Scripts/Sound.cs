using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip soundClip;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    public bool repeat;

    [HideInInspector]
    public AudioSource audioSource;
}
