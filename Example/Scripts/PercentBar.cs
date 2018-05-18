using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentBar : MonoBehaviour {
    public FloatVariable fillLevel;
    private float cFill, oFill, cCap, oCap;
    public FloatVariable fillMaxDynamic;
    public float fillMaxStatic = 100;
    public Image fill_bar;
    public Image fill_bar_change;
    public FloatVariable capLevel;
    public Image cap_bar;
    public Image cap_bar_change;
    public bool cap_attached;
    public float change_rate = 0.5f;
    
    public float FillMax
    {
        get
        {
            if (fillMaxDynamic == null)
                return fillMaxStatic;
            return fillMaxDynamic.RuntimeValue;
        }
    }

    public float FillPercent
    {
        get
        {
            if (fillLevel == null)
                return 0f;
            return fillLevel.RuntimeValue / FillMax;
        }
    }

    public float CapPercent
    {
        get
        {
            if (capLevel == null)
                return 0f;
            return capLevel.RuntimeValue / FillMax;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (fillLevel == null)
            return;
        if(fill_bar_change != null &&
            cFill != FillPercent)
        {
            oFill = cFill;
            cFill = FillPercent;
        }

        if(oFill < cFill && fill_bar_change != null)
        {
            oFill = fill_bar.fillAmount = Mathf.Lerp(oFill, cFill, Time.deltaTime * change_rate);
            fill_bar_change.fillAmount = FillPercent;
        }
        else
        {
            fill_bar.fillAmount = FillPercent;
            if(fill_bar_change != null)
                oFill = fill_bar_change.fillAmount = Mathf.Lerp(oFill, cFill, Time.deltaTime * change_rate);
        }

        if (capLevel == null)
            return;
        if (cap_bar_change != null &&
            cCap != CapPercent)
        {
            oCap = cCap;
            cCap = CapPercent;
        }
        
        if (cap_attached)
        {
            cap_bar_change.fillClockwise = cap_bar.fillClockwise = fill_bar.fillClockwise;
            float fP = oFill;
            if (oFill < cFill)
                fP = cFill;

            if(oCap < cCap && cap_bar_change != null)
            {
                oCap = cap_bar.fillAmount = fP + Mathf.Lerp(oCap,cCap,Time.deltaTime * change_rate);
                cap_bar_change.fillAmount = fP + CapPercent;
            }
            else
            {
                cap_bar.fillAmount = fP + CapPercent;
                if(cap_bar_change != null)
                    oCap = cap_bar_change.fillAmount = fP + Mathf.Lerp(oCap,cCap,Time.deltaTime * change_rate);
            }
        }
        else
        {
            cap_bar_change.fillClockwise = cap_bar.fillClockwise = !fill_bar.fillClockwise;

            if (oCap < cCap && cap_bar_change != null)
            {
                oCap = cap_bar.fillAmount = Mathf.Lerp(oCap, cCap, Time.deltaTime * change_rate);
                cap_bar_change.fillAmount = CapPercent;
            }
            else
            {
                cap_bar.fillAmount = CapPercent;
                if (cap_bar_change != null)
                    oCap = cap_bar_change.fillAmount = Mathf.Lerp(oCap, cCap, Time.deltaTime * change_rate);
            }

        }
    }
}
