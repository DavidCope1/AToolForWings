using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {

    public void reset()
    {
        SceneManager.LoadScene(0);

    }
}
