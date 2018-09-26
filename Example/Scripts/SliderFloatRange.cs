using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFloatRange : MonoBehaviour {

    public FloatRangeVariable floatRange;
    public IntRangeVariable intRange;
    private Slider slider;

	// Use this for initialization
	void Start () {
        slider = GetComponentInChildren<Slider>();
        SetSlider();
	}

    public void ApplySlider()
    {
        if(floatRange != null)
            floatRange.Percent = slider.value;
        if (intRange != null)
            intRange.Percent = slider.value;
    }
    public void SetSlider()
    {
        if(floatRange != null)
            slider.value = floatRange.Percent;
        if (intRange != null)
            slider.value = intRange.Percent;
    }
	
	// Update is called once per frame
	void Update () {
        ApplySlider();
	}

}
