using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwap : MonoBehaviour {

    public Color[] color;
    public IntVariable index;

    public MeshRenderer cube;
    public MeshRenderer sphere;

	// Use this for initialization
	void Update () {
        cube.materials[0].color = color[index.RuntimeValue];
        sphere.materials[0].color = color[index.RuntimeValue];
    }

    public void NextColor()
    {
        index.RuntimeValue++;
        if (index.RuntimeValue > color.Length-1)
            index.RuntimeValue = 0;

        cube.materials[0].color  = color[index.RuntimeValue];
        sphere.materials[0].color = color[index.RuntimeValue];
    }
    
}
