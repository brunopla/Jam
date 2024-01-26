using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioSystem : MonoBehaviour
{

    public List<AudioClip> clips; // lista de clips donde la funcion poner sonido busca.
    public static AudioSystem instance;
    public AudioSource globalAudioSource;
    /// <summary>
    /// patron Singleton
    /// </summary>
    private void Awake()
    {
        if (instance is null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    /// <summary>
    /// poner un sonido, dado su nombre, debe estar en la lista clips 
    /// </summary>
    /// <param name="nombreClipSonido">el nombre del sonido(del archivo)</param>
    /// <param name="source">el source donde sonara este sonido, si no se da, se pone en el global</param>
    /// <param name="delaySegundos">cantidad de segundos antes de que suene el clip, si no se da es 0</param>
    public async void PonerSonido(string nombreClipSonido, AudioSource source = null, float delaySegundos = 0)
    {
        AudioClip clip = clips.Where(clip => clip.name.ToLower() == nombreClipSonido.ToLower()).FirstOrDefault();
        if (clip is null) { print($"no hay clip llamado {nombreClipSonido} en la lista del audio system"); return; }

        await Task.Delay(TimeSpan.FromSeconds(delaySegundos));

        if (source is null) globalAudioSource.PlayOneShot(clip);
        else source.PlayOneShot(clip);
    }
}