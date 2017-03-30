using UnityEngine;
using System.Collections;


public class ControlObject : MonoBehaviour {

    protected int m_currentGlobalState;
    public StateObject.GAMESTATE m_myState;

    public StateObject.GAMESTATE[] m_OtherStates;

    GameObject controler;


    public void Start()
    {
        findControl();
        initalSet();
      
    }

    public void setState(StateObject.GAMESTATE _inState)
    {
        m_myState = _inState;
    }

    public void findControl()
    {
        controler = GameObject.Find("GameControler");
    }

    public void updateState()
    {
        if(controler == null)
        {
            findControl();
        }
        
        //check if our designated state is in the list
        if(m_myState == controler.GetComponent<StateObject>().gameState)
        {
            setAlive(true);
            return;
        }
        else
        {
            setAlive(false);
        }
        //or on our fall backs
        if (m_OtherStates != null)
        {

            if (m_OtherStates.Length != 0)
            {
                foreach (StateObject.GAMESTATE GS in m_OtherStates)
                {
                    if (m_OtherStates.Length != 0)
                    {
                        if (GS == controler.GetComponent<StateObject>().gameState)
                        {
                            setAlive(true);
                            return;
                        }
                    }
                }
            }
        }
    }
    




    public void setAlive(bool _in)
    {
        gameObject.SetActive(_in);
    }
    public void initalSet()
    {
        setAlive(true);
    }


}
