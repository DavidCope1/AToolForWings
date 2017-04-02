using UnityEngine;
using System.Collections.Generic;

public class SplineDecorator : MonoBehaviour
{
    [Range(-30.0f,30.0f )]
    public float zchange;


    public float testVal = -7f;
    private float lastVal;
    public bool seeControlNodes;

    public bool adjustZ;

    private BezierSpline spline;
    private Vector3[] splinePoints;
    public int frequency;
    public bool lookForward;
    public GameObject[] items;
    GameObject item;
    private List<GameObject> vertexPoints = null;
    public List<GameObject> controlPoints;
    MeshManipulator meshMap;

    public List<Transform> controlNodes;

    bool launched = false;

    private MeshMaker shapeHold;
    private MeshMaker shapeholdTwo;

    bool chanaging = false;


    public bool EnableVR;
    public GameObject VRHEAD;
    public GameObject VRHANDR;
    public GameObject VRHANDL;

    public void setZchange(float _In)
    {
        chanaging = true;
        zchange = 30 *_In;

    }


    public void launch()
    {
        if (!launched)
        {
            launched = true;

         

            spline = GetComponent<BezierSpline>();
            controlPoints = new List<GameObject>();
            setControlObjet();
            shapeHold = GameObject.Find("ScriptHolder").GetComponent<MeshMaker>();

            shapeHold.Begin();
            items[0] = shapeHold.pointPrefab;



            vertexPoints = new List<GameObject>();
            splinePoints = new Vector3[spline.points.Length];
            meshMap = GetComponent<MeshManipulator>();
            identPos();
            runCreation();
    
               






            
        }
        
           
        
    }

    void setControlObjet()
    {
        int counter = 0;
        int nodeCounter = 0;
        foreach (Vector3 Vec in spline.points)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            //go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            go.tag = "MOVABLE";
            go.AddComponent<ControlObject>();
            go.GetComponent<ControlObject>().m_myState = StateObject.GAMESTATE.DRAWMEMB;
            go.transform.position = Vec;
            go.transform.localScale = new Vector3(1.0f,2.0f, 1.0f);
            controlPoints.Add(go);
            go.transform.parent = controlNodes[nodeCounter];
            go.GetComponent<Renderer>().material.color = Color.green;

            counter++;
            if ((counter == 3)&&(nodeCounter != 2))
            {
                counter = 0;
                nodeCounter++;
            }
            if (!seeControlNodes)
            {
                go.GetComponent<MeshRenderer>().enabled = false;
               // go.GetComponent<SphereCollider>().enabled = false;
            }


        }
    }


    void identPos()
    {
        int cout = 0;
        foreach (Vector3 vec in spline.points)
        {
            splinePoints[cout++] = vec;
        }
    }

    bool testChange()
    {
    


        if (testIdet() == true || testShape() == true)
        {
            return true;
        }
        return false;
    }

    bool testIdet()
    {

        for (int i = 0; i < spline.points.Length; i++)
        {
            if (spline.points[i] != splinePoints[i])
            {
                identPos();
                vertexPoints.Clear();
                vertexPoints.TrimExcess();
                return true;
            }
        }
        return false;
    }

    bool testLastVal()
    {
        if (lastVal != testVal)
        {
            lastVal = testVal;
            return true;
        }
        return false;
    }

    bool testShape()
    {
        print(meshMap.getUpdated());
        return meshMap.getUpdated();

    }

    void movNode()
    {
        if(spline == null)
        {
            return;
        }

        for (int i = 0; i < spline.points.Length; i++)
        {
            spline.points[i] = controlPoints[i].transform.position;
        }
    }
    bool setToUpdate= false;
    bool manualLaunch = false;
    private void Update()
    {
        if (launched)
        {
            movNode();
            if (testIdet())
            {
                runCreation();

            }
        }

        if(Input.GetKeyDown(KeyCode.U))
        {
            if(!manualLaunch)
            {
                launch();
                manualLaunch = true;
            }
        }





    }

    void runCreation()
    {
        int iterCounter = 0;
        int endAdjuster=0;
        if (frequency <= 0 || items == null || items.Length == 0)
        {
            return;
        }
        float testValForEnd = 0;
        float stepSize = 1f / (frequency * items.Length);
        for (int p = 0, f = 0; f < frequency; f++)
        {
            if(iterCounter++ > 9)
            {
                endAdjuster+= 4 ;
            }

            for (int i = 0; i < items.Length; i++, p++)
            {

               item = Instantiate(items[0]) as GameObject;

                vertexPoints.Add(item);
  
                if (f == frequency - 2)
                {
                    testValForEnd = 1.5f;
                }
                else if (f == frequency - 1)
                {
                    testValForEnd = testValForEnd * 2;
                }

                if (adjustZ)
                {
                    Transform tr = item.transform.GetChild(3).transform;

                    tr.position = tr.position = new Vector3((testVal + (p / 10) - testValForEnd), (tr.position.y), ((-zchange - 10) + endAdjuster));

                    tr = item.transform.GetChild(4).transform;

                    tr.position = tr.position = new Vector3((testVal + (p / 10) - testValForEnd), (tr.position.y), ((-zchange - 10) + endAdjuster));
                 
                }

                 Destroy(item);
                Vector3 position = spline.GetPoint(p * stepSize);
                item.transform.localPosition = position;
                if (lookForward)
                {
                    item.transform.LookAt(position + spline.GetDirection(p * stepSize));
                }
                item.transform.parent = transform;
            }
            foreach (Transform child in item.transform)
            {
                // child.transform.position += new Vector3(5.0f, 0f, 0f);


                vertexPoints.Add(child.gameObject);
                 Destroy(child.gameObject);
            }




        }

        shapeHold.createMesh();
      //  flapHold.bindControl();
    }





    public List<GameObject> getPointList()
    {
        return vertexPoints;
    }


}


/*
	public BezierSpline spline;

	public int frequency;

	public bool lookForward;

	public Transform[] items;

	private void Awake () {
		if (frequency <= 0 || items == null || items.Length == 0) {
			return;
		}
		float stepSize = frequency * items.Length;
		if (spline.Loop || stepSize == 1) {
			stepSize = 1f / stepSize;
		}
		else {
			stepSize = 1f / (stepSize - 1);
		}
		for (int p = 0, f = 0; f < frequency; f++) {
			for (int i = 0; i < items.Length; i++, p++) {
				Transform item = Instantiate(items[i]) as Transform;
				Vector3 position = spline.GetPoint(p * stepSize);
				item.transform.localPosition = position;
				if (lookForward) {
					item.transform.LookAt(position + spline.GetDirection(p * stepSize));
				}
				item.transform.parent = transform;
			}
		}
	}*/
