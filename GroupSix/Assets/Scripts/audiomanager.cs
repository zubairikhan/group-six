using UnityEngine.Audio;
using System;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
   public Sounds[] sounds;
   // [SerializeField] AudioSource as;
   void Awake()
    {

        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sounds,sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }
    public void Stop(){
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.GetComponent<AudioSource>();
            s.source.Stop();
        }
    }

    public void Start(){

    }
  
}
