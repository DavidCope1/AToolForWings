using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SplineBinder: MonoBehaviour {

    BezierSpline BS;
    TimeLineControler TLC;

    public List<GameObject> GoList;


	// Use this for initialization
	void Start () {
        BS = GetComponent<BezierSpline>();
        TLC = transform.root.GetComponent<TimeLineControler>();
	}
	
	// Update is called once per frame
	void Update () {

        //for (int i = 0; i < TLC.animationPoints.Count; i=i+2)
        //{
        //    BS.points[i] = (TLC.animationPoints[i].transform.position) - (TLC.transform.root.transform.position + new Vector3(-12.5f, 0.0f, 0.0f));
        //}
        //for (int i = 0; i < TLC.animationPoints.Count*3;i = i +3)
        //{
        //    BS.SetControlPoint(i,TLC.animationPoints[i].transform.position);
        //}

        BS.SetControlPoint(0, (GoList[0].transform.position)-(transform.root.transform.position) - new Vector3(-15.0f, 0.0f, 0.0f));
        BS.SetControlPoint(3, (GoList[1].transform.position) - (transform.root.transform.position) - new Vector3(-10.0f, 0.0f, 0.0f));
        BS.SetControlPoint(6, (GoList[2].transform.position) - (transform.root.transform.position) - new Vector3(-5.0f, 0.0f, 0.0f));
        BS.SetControlPoint(9, (GoList[3].transform.position) - (transform.root.transform.position) - new Vector3(-0.0f, 0.0f, 0.0f));
        BS.SetControlPoint(12, (GoList[4].transform.position) - (transform.root.transform.position) - new Vector3(5.0f, 0.0f, 0.0f));


    }
}
