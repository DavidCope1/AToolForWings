﻿using UnityEngine;
using System.Collections;

public class ResetPairentPos : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.L))
        {
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
	}
}
