using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Shot;
    public static AudioClip Walk;
    public static AudioClip EnemyDead;
    public static AudioClip EnemyClose;
    public static AudioSource source;
    void Start()
    {
        Shot = Resources.Load<AudioClip>("throwKnife");
        Walk = Resources.Load<AudioClip>("Walk");
        EnemyDead = Resources.Load<AudioClip>("Death");
        EnemyClose = Resources.Load<AudioClip>("Shout");
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "throwKnife":
                source.PlayOneShot(Shot);
                break; 
            case "Walk":
                source.PlayOneShot(Walk);
                break; 
            case "Death":
                source.PlayOneShot(EnemyDead);
                break;
            case "Shout":
                source.PlayOneShot(EnemyClose);
                break;
        }
    }

}
