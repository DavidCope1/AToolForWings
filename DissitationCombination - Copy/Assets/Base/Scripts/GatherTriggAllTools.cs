using UnityEngine;
using System.Collections;

public class GatherTriggAllTools : MonoBehaviour {


    FetherTool[] scripts;
    public CloneObj Clo;
    SplineDecorator spd;

    // Use this for initialization
    void Start () {
        scripts = GetComponents<FetherTool>();
        spd = GetComponent<SplineDecorator>();
        
    }
	
	// Update is called once per frame
	public void triggerTransfom()
    {
      //  spd.Launch();

	    foreach(FetherTool FT in scripts)
        {
            FT.triggerStart();
        }
        Clo.createClone();

	}

    public void TriggerUpdatePos()
    {
        foreach (FetherTool FT in scripts)
        {
            FT.triggerUpdate();
        }

    }
}
