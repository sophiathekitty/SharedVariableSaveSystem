using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour {
    public FloatVariable xPos;
    public float speed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        xPos.RuntimeValue += xMove;
        transform.position = new Vector3(xPos.RuntimeValue, 0, 0);
	}
}
