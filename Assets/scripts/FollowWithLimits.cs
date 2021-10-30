using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWithLimits : MonoBehaviour {
	[SerializeField]
	private Transform maximumX, mininimumX, maximumY, mininimumY;
	[SerializeField]
	private Transform toFollow;
	private float maxX, maxY,minX,minY;

	void Start()
	{
		maxX = maximumX.position.x;
		maxY = maximumY.position.y;
		minX = mininimumX.position.x;
		minY = mininimumY.position.y;
	}
	
	void Update () {
		Vector2 destiny = toFollow.position;
		transform.position = new Vector3(
			destiny.x < maxX && destiny.x > minX ? destiny.x : transform.position.x,
			destiny.y < maxY && destiny.y > minY ? destiny.y : transform.position.y,
			-10);
	}
}
