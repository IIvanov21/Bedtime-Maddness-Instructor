using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OptionsScreen : MonoBehaviour
{
    public Toggle vSync, fullScreenTog;

    public List<ResItem> resolutions = new List<ResItem> ();
    private int selectedResolution;
    public TMP_Text resolutionLabel;
    public TMP_Text qualityText;
    //Quality Settings
    public Dictionary<int, string> qualitySettings = new Dictionary<int, string>(); 

    private int selectedQuality;

    // Start is called before the first frame update
    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;
        if(QualitySettings.vSyncCount == 0 )
        {
            vSync.isOn = false;
        }
        else
        {
            vSync.isOn = true;
        }

        bool foundRes = false;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;

                selectedResolution = i;

                UpdateResLabel();
            }
        }

        if(!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;

            resolutions.Add(newRes);    
            selectedResolution=resolutions.Count-1;
            UpdateResLabel ();
        }

        //Get current Quality Level
        selectedQuality = QualitySettings.GetQualityLevel();


        qualitySettings.Add(0, "Very Low");
        qualitySettings.Add(1, "Low");
        qualitySettings.Add(2, "Medium");
        qualitySettings.Add(3, "High");
        qualitySettings.Add(4, "Very High");
        qualitySettings.Add(5, "Ultra");
        
        UpdateQualityLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResLeft()
    {
        selectedResolution--;
        if(selectedResolution<0)selectedResolution = 0;
        UpdateResLabel();

    }

    public void ResRight()
    {
        selectedResolution++;
        if(selectedResolution>resolutions.Count-1)selectedResolution = resolutions.Count-1;
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal + "X" + resolutions[selectedResolution].vertical;
    }

    public void ApplyGraphics()
    {

        if(vSync.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else QualitySettings.vSyncCount = 0;

        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullScreenTog.isOn);

        QualitySettings.SetQualityLevel(selectedQuality);
    }

    public void UpdateQualityLevel()
    {
        qualityText.text = qualitySettings[selectedQuality];
    }

    public void QLeft()
    {
        selectedQuality--;
        if(selectedQuality<0)selectedQuality = 0;
        UpdateQualityLevel();
    }

    public void QRight()
    {
        selectedQuality++;
        if(selectedQuality>qualitySettings.Count-1)selectedQuality = qualitySettings.Count-1;
        UpdateQualityLevel();
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal;
    public int vertical;
}