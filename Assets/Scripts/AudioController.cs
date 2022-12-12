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
        float percentage = ((-80.0f-master.value)/(-80.0f))*100; 
        masterText.text = percentage.ToString();
        //Master value
        PlayerPrefs.SetFloat("masterVolume", master.value);
        PlayerPrefs.Save();
    }

    public void SetAmbientSound()
    {
        audioMixer.SetFloat("AmbientSound", ambient.value);
        float percentage = ((-80.0f - ambient.value) / (-80.0f)) * 100;
        ambientText.text = percentage.ToString();
        PlayerPrefs.SetFloat("ambientVolume", ambient.value);
        PlayerPrefs.Save();
    }

    public void SetMusicSound()
    {
        audioMixer.SetFloat("Music", music.value);
        float percentage = ((-80.0f - music.value) / (-80.0f)) * 100;
        musicText.text = percentage.ToString();
        PlayerPrefs.SetFloat("musicVolume", music.value);
        PlayerPrefs.Save();
    }

    public void SetPlayerSound()
    {
        audioMixer.SetFloat("Player", player.value);
        float percentage = ((-80.0f - player.value) / (-80.0f)) * 100;
        playerText.text = percentage.ToString();
        PlayerPrefs.SetFloat("playerVolume", player.value);
        PlayerPrefs.Save();//How can we make this better?
    }

    public void SetStartingValues()
    {
        float percentage = 0, value = 0;
        int wholeNum = 0;


        value = PlayerPrefs.GetFloat("masterVolume");
        audioMixer.SetFloat("Master", value);
        master.value = value;
        percentage = ((-80.0f - value) / (-80.0f)) * 100;
        wholeNum = (int)percentage;
        masterText.text = wholeNum.ToString();

        value = PlayerPrefs.GetFloat("ambientVolume");
        audioMixer.SetFloat("AmbientSound", value);
        ambient.value = value;  
        percentage = ((-80.0f - value) / (-80.0f)) * 100;
        wholeNum = (int)percentage;
        ambientText.text = wholeNum.ToString();

        value = PlayerPrefs.GetFloat("musicVolume");
        audioMixer.SetFloat("Music", value);
        music.value = value;
        percentage = ((-80.0f - value) / (-80.0f)) * 100;
        wholeNum = (int)percentage;
        musicText.text = wholeNum.ToString();

        //audioMixer.GetFloat("Player", out value);
        value = PlayerPrefs.GetFloat("playerVolume");
        audioMixer.SetFloat("Player", value);
        player.value = value;
        percentage = ((-80.0f - value) / (-80.0f)) * 100;
        wholeNum = (int)percentage;
        playerText.text = wholeNum.ToString();
    }

}
