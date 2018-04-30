using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSwitch : MonoBehaviour {

    public GameObject cube;
    public GameObject sphere;

    public BoolVariable shape;

	// Use this for initialization
	void Update () {
        cube.SetActive(!shape.RuntimeValue);
        sphere.SetActive(shape.RuntimeValue);
    }

    public void ToggleShape()
    {
        shape.RuntimeValue = !shape.RuntimeValue;

        cube.SetActive(!shape.RuntimeValue);
        sphere.SetActive(shape.RuntimeValue);
    }
}
