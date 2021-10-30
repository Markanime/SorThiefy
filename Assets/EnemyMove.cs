using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	[SerializeField]
	private Transform[] templatePattern;
	private List<Transform> pattern = new List<Transform>();
	[SerializeField]
	private float speed = 5;
	private Transform target;
	private Rigidbody2D rb;
	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}
	void LateUpdate () {
		if (!target)
		{
			CalculateTarget();
			return;
		}
		rb.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
		if (Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
			CalculateTarget();
        }
	}

	void CalculateTarget()
    {
        if (pattern.Count <= 0)
        {
			pattern = new List<Transform>(templatePattern);
        }
		target = transform.GetNearest(pattern);
		pattern.Remove(target);
	}

}
