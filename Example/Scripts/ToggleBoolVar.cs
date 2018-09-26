using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleBoolVar : MonoBehaviour {

    public BoolVariable boolVariable;
    private Toggle toggle;

	// Use this for initialization
	void Start () {
        toggle = GetComponentInChildren<Toggle>();
        SetToggle();
	}

    public void ApplyToggle()
    {
        if (boolVariable != null)
            boolVariable.RuntimeValue = toggle.isOn;
    }
    public void SetToggle()
    {
        if (boolVariable != null)
            toggle.isOn = boolVariable.RuntimeValue;
    }


    // Update is called once per frame
    void Update () {
        ApplyToggle();
	}
}
