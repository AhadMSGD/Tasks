using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ROMCalibration : MonoBehaviour
{
    public Slider romSlider;
    public Slider romSlider2;
    public float handPosition = 100f;
    public float minROM = 0f;
    public float maxROM = 100f;
    public float stepValue = 5f; 

    public Text innerROMText;
    public Text outerROMText;
    public Text arm;
   
    private float innerROM;
    private float outerROM;

    private float handclosed;
    private float handopened;

    void Start()
    {
        romSlider.maxValue = maxROM;
        romSlider.minValue = minROM;
        romSlider.value = handPosition;

        romSlider2.maxValue = maxROM;
        romSlider2.minValue = minROM;
        romSlider2.value = handPosition;

        handclosed = minROM;

    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.LeftArrow))  // if clicking LeftArrow  Calculationg slider value
        {
            handPosition = Mathf.Min(maxROM, handPosition + stepValue);
            romSlider.value = handPosition;
            romSlider2.value = handPosition;

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))  // if clicking RightArrow  Calculationg slider value
        {
            handPosition = Mathf.Max(minROM, handPosition - stepValue);
            romSlider.value = handPosition;
            romSlider2.value = handPosition;
        }
    }



    

    public void ShowInnerValue()  //When Button click Print currrent Inner Value
    {
        innerROM = handPosition;
        innerROMText.text = "Inner ROM: " + innerROM.ToString("F1") + " mm";
        Debug.Log("Inner ROM recorded: " + innerROM.ToString("F1") + " mm");


        // Calculate ARM using the formula ARM = (handopened - handclosed) / 2
        handopened = innerROM;  
        float ARM = (handopened - handclosed) / 2;  // Calculate ARM
        Debug.Log("Calculated ARM: " + ARM.ToString("F1") + " mm");
        arm.text = "Calculated ARM: " + ARM.ToString("F1") + " mm";
    }

    public void ShowOuterValue()  ////When Button click Print currrent Outer Value
    {
        outerROM = handPosition;
        outerROMText.text = "Outer ROM: " + outerROM.ToString("F1") + " mm";
         Debug.Log("Outer ROM recorded: " + outerROM.ToString("F1") + " mm");

        handopened = outerROM;  // Record the hand opened position when this button is pressed
        float ARM = (handopened - handclosed) / 2;  
        Debug.Log("Calculated ARM: " + ARM.ToString("F1") + " mm");
        arm.text = "Calculated ARM: " + ARM.ToString("F1") + " mm";

    }

  
}
