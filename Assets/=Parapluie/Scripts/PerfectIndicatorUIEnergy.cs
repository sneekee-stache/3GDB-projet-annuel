using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class PerfectIndicatorUIEnergy : MonoBehaviour
{
    public Player Player;
    public Image PrivateImage;
    public RectTransform PrivateRectTransform;
    private float Rotationx;
    private float Rotationy;
    private float Rotationz;
    
    void Start()
    {
        Rotationz = PrivateRectTransform.localRotation.z;
    }


    void Update()
    {
        Rotationx = PrivateRectTransform.localRotation.x;
        Rotationy = PrivateRectTransform.localRotation.y;

        float EnergyPercentage = Player.EnergieRW / 100f;
        float EnergyPlacement = Mathf.Lerp(-30, -150, EnergyPercentage) + 5;
        EnergyPlacement = Mathf.Clamp(EnergyPlacement, -137, -35);
        
        PrivateRectTransform.localRotation = Quaternion.Euler(Rotationx, Rotationy, EnergyPlacement);
        if (Player.EnergieDown) PrivateImage.enabled = false;
        else PrivateImage.enabled = true;
    }
}

