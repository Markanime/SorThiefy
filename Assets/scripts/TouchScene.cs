using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchScene : MonoBehaviour {
    public bool autoload = false;
    public string scene = "";
	public float wait = 1;
    public float waitAutoload = 1;
    // Update is called once per frame
    void Update () {
        wait -= Time.deltaTime;
        waitAutoload -= Time.deltaTime;
        if (wait <= 0)
        {
            if (Input.GetMouseButtonDown(0) || autoload && waitAutoload <=0)
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
}
