using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoundManager : Singleton<SoundManager>
{

    [SerializeField] AudioSource audioSourcePrefab;
    List<AudioSource> audioSources = new List<AudioSource>();

    [SerializeField] List<AudioClip> audioClips = new List<AudioClip>();
    // Start is called before the first frame update
    void Start()
    {
        audioClips = Resources.LoadAll<AudioClip>("Sound").ToList();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string audioClipName)
    {
        AudioClip audioClip = null;
        var tmp_audioClip = audioClips.Where(a =>
       {
           return a.name.ToLower().Equals(audioClipName.ToLower());
       });

        if (tmp_audioClip.Any())
            audioClip = tmp_audioClip.First();

        //foreach (AudioClip a in audioClips)
        //{
        //    if (!a.name.ToLower().Equals(audioClipName.ToLower()))
        //        continue;

        //    audioClip = a;
        //}

        if(audioClip == null)
        {
            Debug.LogError("Cannot find audioClip "+audioClipName);
            return;
        }

        var tmp_audioSource = audioSources.Where(A =>
        {
            return !A.gameObject.activeSelf;
        });

        if (tmp_audioSource.Any())
        {
            SetAudioClip(tmp_audioSource.First(), audioClip);
            return;
        }

        //foreach (AudioSource A in audioSources)
        //{
        //    if (A.gameObject.activeSelf)
        //        continue;

        //    SetAudioClip(A, audioClip);
        //    return;
        //}

        AudioSource A2 = Instantiate<AudioSource>(audioSourcePrefab, this.transform.position, Quaternion.identity);
        audioSources.Add(A2);

        SetAudioClip(A2, audioClip);
    }

    void SetAudioClip(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.gameObject.SetActive(true);
        audioSource.Play();
    }
}
