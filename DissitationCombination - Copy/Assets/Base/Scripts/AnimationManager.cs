using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AnimationManager : MonoBehaviour {


    public List<BezierSpline> animationList;
    public SplineFollower SpF;
    int currentSpline = 0;

    void Start()
    {
        SpF.spline = animationList[currentSpline];
    }

	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.O))
        {

            if (currentSpline < animationList.Count)
            {
                SpF.spline = animationList[currentSpline++];
            }
            else
            {
                currentSpline = 0;
                SpF.spline = animationList[currentSpline];

            }
        }
	}
}
