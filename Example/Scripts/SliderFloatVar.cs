using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class SliderFloatVar : MonoBehaviour {

    public FloatVariable variable;
    private Slider slider;
	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        slider.value = variable.RuntimeValue;
	}
    private void Update()
    {
        UpdateVariable();
    }
    // update variable
    public void UpdateVariable()
    {
        variable.RuntimeValue = slider.value;
    }
}
