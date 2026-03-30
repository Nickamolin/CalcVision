using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueToText : MonoBehaviour
{
    public Slider sliderUI;
    private Text sliderValue;


    // Start is called before the first frame update
    void Start()
    {
        sliderValue = GetComponent<Text>();
        ShowSliderValue();
    }

    // Update is called once per frame
    public void ShowSliderValue()
    {
        sliderValue.text = "" + sliderUI.value;
        GlobalVariables.universalDomain = sliderUI.value;
        TwoDGlobalVariables.universalDomain = sliderUI.value;
    }
}
