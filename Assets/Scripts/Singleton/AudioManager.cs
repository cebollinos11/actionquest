using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum AudioClipsType
{
    enemyDead,throwProjectile,thump,getHurt,dash
}


public class AudioManager : Singleton<AudioManager>
{
    AudioSource mainAudioSource;
    [System.Serializable]
    public class AudioType
    {
        public AudioClipsType type;
        public AudioClip clip;
    }

    [SerializeField]
    List<AudioClip> backgroundSongs;

    public List<AudioType> audioList = new List<AudioType>();
    Dictionary<AudioClipsType, AudioClip> audioMap = new Dictionary<AudioClipsType, AudioClip>();

    public static void PlaySpecific(AudioClip soundEffect)
    {
        Instance.mainAudioSource.PlayOneShot(soundEffect);
    }

    public static void PlayClip(AudioClipsType type)
    {
        Instance.mainAudioSource.PlayOneShot(Instance.audioMap[type]);

        //Instance.mainAudioSource.clip = Instance.audioMap[type];
        //Instance.mainAudioSource.Play();

    }

    public static void PlayBgSong(int i)
    {

        //Instance.mainAudioSource.PlayOneShot(Instance.backgroundSongs[i]);
        Instance.mainAudioSource.clip = Instance.backgroundSongs[i];
        Instance.mainAudioSource.loop = true;
        Instance.mainAudioSource.Play();

    }

    public static void AudioShutdown()
    {
        StopAll();
        PlayBgSong(1);
    }

    public static void StopAll()
    {
        Instance.mainAudioSource.Stop();
    }

    // Use this for initialization
    void Start()
    {
        mainAudioSource = transform.GetComponent<AudioSource>();
        foreach (AudioType audio in audioList)
        {
            audioMap.Add(audio.type, audio.clip);
        }

        audioMap[AudioClipsType.enemyDead] = Resources.Load("Audio/SFX/enemyDies") as AudioClip;
        audioMap[AudioClipsType.throwProjectile] = Resources.Load("Audio/SFX/lasershoot") as AudioClip;
        audioMap[AudioClipsType.thump] = Resources.Load("Audio/SFX/hitHurt") as AudioClip;
        audioMap[AudioClipsType.getHurt] = Resources.Load("Audio/SFX/Hit_Hurt2") as AudioClip;
        audioMap[AudioClipsType.dash] = Resources.Load("Audio/SFX/RPG Sound Pack/battle/sword-unsheathe") as AudioClip;


    }




}