using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeLineControler : MonoBehaviour {

    public List<GameObject> animationPoints;
    public List<GameObject> markerPoint;
    public SplineFollower SPF;
    public GameObject startPos;
    public GameObject endPos;
    public GameObject bar;
   // private LineRenderer LR;
    public SplineFollower currentPoint;

    public enum axis {
        XPos,
        YPos,
        ZPos
    }
    public axis axisSelect;

    private float currentPos;
    public float curentZ;

	// Use this for initialization
	void Start () {

        bar.transform.position = startPos.transform.position;
      //  LR = GetComponent<LineRenderer>();
        
    }
	
	// Update is called once per frame
	void Update () {
        float currentVal = currentPoint.progress;

       

 
        int counter = 0;
        //foreach(GameObject go in markerPoint)
        //{
        //    LR.SetPosition(counter, animationPoints[counter].transform.position);
        //        counter++;
        //}


        bar.transform.position = Vector3.Lerp(startPos.transform.position, endPos.transform.position, currentVal);

        int currentTarget=0;
        int prevTarget=0;  

        if(currentVal < 0.25)
        {
            prevTarget = 0;
            currentTarget = 1;

        }
        else if ((currentVal >= 0.25)&&(currentVal <0.50))
        {

            prevTarget = 1;
            currentTarget = 2;
        }
        else if ((currentVal >= 0.50) && (currentVal < 0.75))
        {

            prevTarget = 2;
            currentTarget = 3;
        }
        else if (currentVal >= 0.75)
        {

            prevTarget = 3;
            currentTarget = 0;
        }

        curentZ = currentPoint.transform.position.z;//Mathf.Lerp(animationPoints[prevTarget].transform.position.z, animationPoints[currentTarget].transform.position.z, currentVal/2 );
        curentZ = (curentZ - transform.root.transform.position.z);
    }
}
