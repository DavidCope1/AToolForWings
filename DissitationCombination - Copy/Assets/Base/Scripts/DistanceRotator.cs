using UnityEngine;
using System.Collections;

public class DistanceRotator : MonoBehaviour {
    public GameObject distanceObject;
    public int positionOnWing;
    private FetherRotator FR;

    public float Y;

    void Start()
    {
        
        FR = GameObject.Find("ScriptHolder").GetComponent<FetherRotator>();
    }

    public float baseVal = 0.0f;
    // Update is called once per frame
    void Update () {

        Y = FR.YVal;

        float distance = Vector3.Distance(transform.position, distanceObject.transform.position);

        transform.rotation = Quaternion.Euler(FR.XVal, (FR.YVal + -(Mathf.Clamp(distance,0.0f,90.0f))), FR.ZVal );
       // print(transform.rotation);
        
    }
}
