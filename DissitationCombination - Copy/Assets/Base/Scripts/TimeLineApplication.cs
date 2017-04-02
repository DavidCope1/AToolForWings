using UnityEngine;
using System.Collections;

public class TimeLineApplication : MonoBehaviour
{

    public GameObject timeline;
    GameObject valueProduce;
    Vector3 baseRot;
    TimeLineControler TLC;
    int delay = 10;
    bool setUp = false;
    public bool invertVal;

    void Awake()
    {

    }

    void delayedSetup()
    {
        valueProduce = timeline.transform.GetChild(0).gameObject;
        TLC = valueProduce.GetComponent<TimeLineControler>();
        baseRot = transform.rotation.eulerAngles;

        if(invertVal)
        {
            baseRot = -baseRot;
        }

    }


    void Update()
    {
        if(delay > 0 )
        {
            delay = delay - 1;
            return;
        }
        if(!setUp)
        {
            delayedSetup();
            setUp = true;
        }



        switch(TLC.axisSelect)
        {
            case TimeLineControler.axis.XPos:
                transform.rotation = new Quaternion(baseRot.z - TLC.curentZ, baseRot.y, baseRot.z, 1.0f);

                break;
            case TimeLineControler.axis.YPos:
                transform.rotation = new Quaternion(baseRot.x, baseRot.y + (TLC.curentZ), baseRot.z, 1.0f);
              
                break;
            case TimeLineControler.axis.ZPos:
                transform.rotation = new Quaternion(baseRot.x, baseRot.y, baseRot.z - TLC.curentZ, 1.0f);

                break;

        }



    }


}
