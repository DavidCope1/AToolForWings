﻿using UnityEngine;
using System.Collections;

public class AnimationReset : MonoBehaviour {

    public GameObject LAS;
    public GameObject Root;
    public GameObject Pt1;
    public GameObject Pt2;

    private Transform RootStartRot;
    private Transform Pt1Rot;
    private Transform Pt2Rot;

    public void getRootRots()
    {
        RootStartRot = Root.transform;
        Pt1Rot = Pt1.transform;
        Pt2Rot = Pt2.transform;

    }

    public void resetAnimation()
    {
        RootStartRot.transform.localRotation = Root.transform.rotation;
    
        Pt1.transform.rotation = Pt1Rot.rotation;

        Pt2.transform.rotation = Pt2Rot.rotation;





    }


}
