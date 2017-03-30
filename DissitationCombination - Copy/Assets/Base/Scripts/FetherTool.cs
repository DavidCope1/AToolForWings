﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Bult from :http://catlikecoding.com/unity/tutorials/curves-and-splines/

public class FetherTool : MonoBehaviour {
    public BezierSpline spline;
    public bool enabaled;
    public bool rotRight;
    public bool rotLeft;
    public int frequency;

    public float publicTool;
    public bool lookForward;

    public Transform Root;
    public Transform ControlObjectOne;
    public Transform ControlObjectTwo;

    public GameObject[] items;
    private List<GameObject> createdFethers;

    //inital setup and populating pool
    private void Awake()
    {
        if (enabaled)
        {
            createdFethers = new List<GameObject>();
            if (frequency <= 0 || items == null || items.Length == 0)
            {
                return;
            }
            float stepSize = frequency * items.Length;
            if (spline.Loop || stepSize == 1)
            {
                stepSize = 1f / stepSize;
            }
            else
            {
                stepSize = 1f / (stepSize - 1);
            }
            for (int p = 0, f = 0; f < frequency; f++)
            {
                for (int i = 0; i < items.Length; i++, p++)
                {
                    GameObject item = Instantiate(items[i]) as GameObject;
                    Vector3 position = spline.GetPoint(p * stepSize);
                    item.gameObject.AddComponent<DistanceRotator>();
                    item.GetComponent<DistanceRotator>().distanceObject = GameObject.Find("Root");
                    item.GetComponent<DistanceRotator>().positionOnWing = f;

                    item.transform.localPosition = position;

                    placeOwner(item);
                    createdFethers.Add(item);
                    if (lookForward)
                    {
                        item.transform.LookAt(position + spline.GetDirection(p * stepSize));
                    }
                    //item.transform.parent = transform;
                }
            }
        }
    }

    void Update()
    {
        //Add If moved here


        //float stepSize = frequency * items.Length;
        //if (spline.Loop || stepSize == 1)
        //{
        //    stepSize = 1f / stepSize;
        //}
        //else
        //{
        //    stepSize = 1f / (stepSize - 1);
        //}
        //for (int p = 0, f = 0; f < frequency; f++)
        //{
        //    for (int i = 0; i < items.Length; i++, p++)
        //    {
        //        GameObject pos = new GameObject();
        //        Vector3 position = spline.GetPoint(p * stepSize);

        //        pos.transform.localPosition = position;

        //       // placeOwner(pos);
        //       // createdFethers.Add(item);
        //        //if (lookForward)
        //        //{
        //        //    item.transform.LookAt(position + spline.GetDirection(p * stepSize));
        //        //}
        //        //item.transform.parent = transform;
        //    }
        //}



    }


    void placeOwner(GameObject Go)
    {
        
        if(Go.GetComponent<DistanceRotator>().positionOnWing <34)
        {
            Go.transform.SetParent(Root);
        
        }
        else if(Go.GetComponent<DistanceRotator>().positionOnWing < 67)
        {
         Go.transform.SetParent(ControlObjectOne);
            
        }
        else
        {
            Go.transform.SetParent(ControlObjectTwo);
          
        }

    }
}