using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
    public TMP_Text SoundUI;
    private Slider slider;
    public void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("MusicVolume");
        SetUI(slider.value);
    }
    public void SetUI(float val)
    {
        int value = (int)(val * 100);
        SoundUI.text = value.ToString();
    }
}
