using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField]
    private Slider master, music, ambient, player;
    [SerializeField]
    private TMP_Text masterText, musicText,ambientText, playerText;

    private void Start()
    {
        SetStartingValues();
        //Bind the Sliders to correct methods
        master.onValueChanged.AddListener(delegate { SetMasterSound(); });
        music.onValueChanged.AddListener(delegate { SetMusicSound(); });
        ambient.onValueChanged.AddListener(delegate { SetAmbientSound(); });
        player.onValueChanged.AddListener(delegate { SetPlayerSound(); });

    }

    public void SetMasterSound()
    {
        audioMixer.SetFloat("Master", master.value);
        float percentage = ((-80.0f-master.value)/(-80.0f-20.0f))*100; 
        masterText.text = percentage.ToString();
    }

    public void SetAmbientSound()
    {
        audioMixer.SetFloat("AmbientSound", ambient.value);
        float percentage = ((-80.0f - ambient.value) / (-80.0f - 20.0f)) * 100;
        ambientText.text = percentage.ToString();
    }

    public void SetMusicSound()
    {
        audioMixer.SetFloat("Music", music.value);
        float percentage = ((-80.0f - music.value) / (-80.0f - 20.0f)) * 100;
        musicText.text = percentage.ToString();
    }

    public void SetPlayerSound()
    {
        audioMixer.SetFloat("Player", player.value);
        float percentage = ((-80.0f - player.value) / (-80.0f - 20.0f)) * 100;
        playerText.text = percentage.ToString();
    }

    public void SetStartingValues()
    {
        float percentage = 0, value = 0;
        int wholeNum = 0;


        audioMixer.GetFloat("Master", out value);
        master.value = value;
        percentage = ((-80.0f - value) / (-80.0f - 20.0f)) * 100;
        wholeNum = (int)percentage;
        masterText.text = wholeNum.ToString();

        audioMixer.GetFloat("AmbientSound", out value);
        ambient.value = value;  
        percentage = ((-80.0f - value) / (-80.0f - 20.0f)) * 100;
        wholeNum = (int)percentage;
        ambientText.text = wholeNum.ToString();

        audioMixer.GetFloat("Music", out value);
        music.value = value;
        percentage = ((-80.0f - value) / (-80.0f - 20.0f)) * 100;
        wholeNum = (int)percentage;
        musicText.text = wholeNum.ToString();

        audioMixer.GetFloat("Player", out value);
        player.value = value;
        percentage = ((-80.0f - value) / (-80.0f - 20.0f)) * 100;
        wholeNum = (int)percentage;
        playerText.text = wholeNum.ToString();
    }

}
