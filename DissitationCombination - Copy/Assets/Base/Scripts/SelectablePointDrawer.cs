using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SelectablePointDrawer : MonoBehaviour {

    public GameObject template;
    public SplineDecorator SP;
    public Camera displayCam;
    public Canvas canvas;
    List<GameObject> pointList;
    bool hasCreated = false;

    void createPoints()
    {
        pointList = new List<GameObject>();
        foreach(GameObject go in SP.controlPoints)
        {
            GameObject GO = Instantiate(template);
            GO.GetComponent<RectTransform>().anchoredPosition = template.GetComponent<RectTransform>().anchoredPosition;
            pointList.Add(GO);

        }
    }

	// Update is called once per frame
	void Update () {


        if(isReady()&& hasCreated == false)
        {
            hasCreated = true;
            createPoints();
        }
        else
        {
            return;
        }

	
        foreach(GameObject go in SP.controlPoints)
        {
            displayCam.WorldToScreenPoint(go.transform.position);
        }



	}
    bool isReady()
    {
        if (SP.controlPoints.Count > 0)
        {
            return true;
        }
        else return false;
    }


}
