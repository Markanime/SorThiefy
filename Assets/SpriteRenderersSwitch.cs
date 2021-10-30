using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRenderersSwitch : MonoBehaviour {
	[SerializeField]
	private SpriteRenderer master;
	[SerializeField]
	private SpriteRenderer slave;
	
	void Update () {
		slave.enabled = !master.enabled;
	}
}
