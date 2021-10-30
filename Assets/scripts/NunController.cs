using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class NunController : MonoBehaviour {
	[SerializeField]
	private string HorizontalAxis = "Horizontal", VerticalAxis = "Vertical";
	[SerializeField]
	private float speed = 10;
	[SerializeField]
	private Animator walkAnimator;
	private Rigidbody2D myRigidbody2D;
	private string walk = "walk";
	private float x, y;
	void Start () {
		myRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		x = Input.GetAxis(HorizontalAxis);
		y = Input.GetAxis(VerticalAxis);

		if( x > 0.1f || x < -0.1f || y > 0.1f || y <-0.1f)
			walkAnimator.SetBool(walk, true);
        else
			walkAnimator.SetBool(walk, false);

		walkAnimator.SetFloat("x", x);
		walkAnimator.SetFloat("y", y);
	}

	void LateUpdate()
    {
		myRigidbody2D.MovePosition(myRigidbody2D.position + (new Vector2 (x, y) * speed * Time.deltaTime));
    }

}
