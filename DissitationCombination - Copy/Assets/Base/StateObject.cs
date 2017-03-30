using UnityEngine;
using System.Collections;

public class StateObject : MonoBehaviour {

public enum GAMESTATE
    {
            TITLE = 0,
            DRAWWING,
            DRAWMEMB,
            ANIMATE,
            MUSTBELAST
    }
    public GAMESTATE gameState;
    private GAMESTATE lastState;
    ControlObject[] objList;



    void Start()
    {
        setMainState();
        objList = FindObjectsOfType<ControlObject>();
 
        change();
    }

    public void chanageState(int _in)
    {
        gameState = (GAMESTATE)_in;
        updateObjects();
    }

    void updateObjects()
    {

        foreach(ControlObject obj in objList)
        {
            if (obj != null)
            {
                obj.gameObject.SetActive(true);
                obj.updateState();
            }


        }
    }

    void Update()
    {
        if(gameState != lastState)
        {
            change();
            
        }
        
    }

    void change()
    {
        updateObjects();
        setMainState();
  
    }

    void setMainState()
    {
        lastState = gameState;
    }

    void initalSet()
    {

        foreach (ControlObject obj in objList)
        {
            obj.updateState();
        }
    }

    
    
}
