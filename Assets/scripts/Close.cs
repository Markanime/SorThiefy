using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour {
	void Update () {
		if (Input.GetButtonUp("Cancel"))
			Application.Quit();
	}

	void Awake()
    {
		DontDestroyOnLoad(this.gameObject);
    }
}
