using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundMute : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource[] source;



    [SerializeField]
    bool sound;

    public TextMeshProUGUI text;

    private void Awake()
    {
       
    }


    void Start()
    {
        source = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    }

    // Update is called once per frame
   public  void SoundOnOFF ()
    {
        sound = !sound;

        if (sound)
        {
            text.text = "SOUND OFF";
            source = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource music in source)
            {
                music.mute = true;
                // Debug.Log("Sound On");
            }
        }
        else
        {
            text.text = "SOUND ON";
            source = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource music in source)
            {
                music.mute = false;
                // Debug.Log("Sound On");
            }
        }
    }
}
