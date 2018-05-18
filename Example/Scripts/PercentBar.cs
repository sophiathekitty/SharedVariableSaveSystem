using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentBar : MonoBehaviour {

    public AttributeVariable attribute;

    private float cFill, oFill, cCap, oCap;
    public Image fill_bar;
    public Image fill_bar_change;
    public Image cap_bar;
    public Image cap_bar_change;
    public bool cap_attached;
    public float change_rate = 0.5f;
    
    public float FillMax
    {
        get
        {
            return attribute.RuntimeMax;
        }
    }

    public float FillPercent
    {
        get
        {
            return attribute.Percent;
        }
    }

    public float CapPercent
    {
        get
        {
            return attribute.RuntimeUnavailable / FillMax;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (attribute == null)
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
