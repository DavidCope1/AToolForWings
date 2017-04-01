using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    public List<ControlObject> objListdy;


    void Start()
    {
        objListdy = new List<ControlObject>();
        setMainState();

        ControlObject[] objList = FindObjectsOfType<ControlObject>();

        foreach (ControlObject ctrl in objList)
        {
            objListdy.Add(ctrl);
        }

        change();
    }

   


    public void chanageState(int _in)
    {
        gameState = (GAMESTATE)_in;
        updateObjects();
    }

    void updateObjects()
    {

        foreach(ControlObject obj in objListdy)
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

        if (gameState != lastState)
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

        foreach (ControlObject obj in objListdy)
        {
            obj.updateState();
        }
    }

    
    
}
