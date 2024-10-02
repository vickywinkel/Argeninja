using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource source;
    public AudioClip cortarComida; 
    public AudioClip cortarPlato; 
    public AudioClip nuevaComida; 

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else //si instance es nulo, vacio
        {
            Instance = this; //yo soy instance --> este script
        }

        DontDestroyOnLoad(this);

        source = GetComponent<AudioSource>(); //usamos el get component para agarrar el audio sorce
    }

    public void PlaySound(AudioClip clip)
    {
        //source.Stop();
        //source.loop = false;
        source.PlayOneShot(clip);
    }
}
