using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;

[ExecuteInEditMode]
public class GlobalSettings : MonoBehaviour
{
    [Header("Variables/Inputs:")]

    [SerializeField]
    private Material nightTexture;

    [SerializeField]
    private Material dayTexture;

    [SerializeField]
    private LightingSettings dayLightSettings;

    [SerializeField]
    private LightingSettings nightLightSettings;


    [SerializeField]
    private Light sunLamp;


    [Header("Settings:")]


    [SerializeField]
    private bool nightTime = false;
     

    // Update is called once per frame
    void Update()
    {
        //if(!Application.isPlaying)
        {
            if (nightTime)
            {
                RenderSettings.skybox = nightTexture;
                //Lightmapping.lightingSettings = nightLightSettings;
                sunLamp.enabled = false;
            }
            else
            {
                RenderSettings.skybox = dayTexture;
                //Lightmapping.lightingSettings = dayLightSettings;
                sunLamp.enabled = true;
            }
        }
    }
    public void NightMode()
    {
        nightTime = true;
    }
    public void DayMode()
    {
        nightTime = false;
    }
}
