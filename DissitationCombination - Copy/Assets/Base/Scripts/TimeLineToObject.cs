using UnityEngine;
using System.Collections;

public class TimeLineToObject : MonoBehaviour {

    LineRenderer LR;
    public GameObject RootObj;
	// Use this for initialization
	void Start () {
        LR = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        LR.SetPosition(0, transform.position);
        LR.SetPosition(1,RootObj.transform.position);

	}
}
