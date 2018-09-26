using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ApplyAudioSetting : MonoBehaviour {
    public FloatRangeVariable floatRange;
    public FloatVariable floatVariable;
    public AudioMixer audioMixer;
    public string targetValue;
    public AnimationCurve curve = new AnimationCurve(new Keyframe(0f,0f), new Keyframe(1f,1f));

    public float FloatValue
    {
        get
        {
            if (floatRange != null)
                return floatRange.RuntimeValue;
            if (floatVariable != null)
                return floatVariable.RuntimeValue;
            return 0f;
        }
        set
        {
            if (floatRange != null)
                floatRange.RuntimeValue = value;
            if (floatVariable != null)
                floatVariable.RuntimeValue = value;
        }
    }


    public void ApplyValue()
    {
        if (targetValue == "")
            return;
        if (curve.keys.Length > 0 && floatRange != null)
            audioMixer.SetFloat(targetValue, Mathf.Lerp(floatRange.MinValue,floatRange.MaxValue, curve.Evaluate(floatRange.Percent)));
        else
            audioMixer.SetFloat(targetValue, FloatValue);
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        ApplyValue();
	}
}
