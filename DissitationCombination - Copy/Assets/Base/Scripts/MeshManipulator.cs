using UnityEngine;
using System.Collections;

public class MeshManipulator : MonoBehaviour {

    public Camera cameraIn;

   // public GameObject camPosOneTesting;
  //  public GameObject camPosTwoTesting;
  //  public GameObject camPosThreeTesting;

    bool updated = false;
    bool selected = false;
    private GameObject currentSelect;
    public Material setCol;
    Material matHold;
    Transform pairnentHold;

    public bool getUpdated()
    {
        return updated;
    }

    void Update()
    {

        RaycastHit hit;
        Ray ray = cameraIn.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(ray.origin, ray.direction);

            if (Input.GetMouseButtonDown(0) )
            {
                if(!selected && hit.transform.tag == "MOVABLE")
                {
                    currentSelect = hit.transform.gameObject;
                    matHold = currentSelect.GetComponent<Renderer>().material;
                    currentSelect.GetComponent<Renderer>().material = setCol;
                    selected = true;
                    pairnentHold = hit.transform.parent;
                    hit.transform.parent = null;
                }

                else if(selected)
                {
                    currentSelect.GetComponent<Renderer>().material = matHold;
                    currentSelect = null;
                    selected = false;
                    updated = true;
                    currentSelect.transform.parent = pairnentHold;
                    pairnentHold = null;
                }
                           


            }
            //if (Input.GetKey(KeyCode.U))
            //{
            //    cameraIn.transform.position = camPosOneTesting.transform.position;
            //    cameraIn.transform.rotation = camPosOneTesting.transform.rotation;
            //}
            //if (Input.GetKey(KeyCode.I))
            //{
            //    cameraIn.transform.position = camPosTwoTesting.transform.position;
            //    cameraIn.transform.rotation = camPosTwoTesting.transform.rotation;
            //}
            //if (Input.GetKey(KeyCode.O))
            //{
            //    cameraIn.transform.position = camPosThreeTesting.transform.position;
            //    cameraIn.transform.rotation = camPosThreeTesting.transform.rotation;
            //}


            if (selected)
            {
                currentSelect.transform.position = new Vector3(hit.point.x, 0, hit.point.z);

            }



        }



    }
}
