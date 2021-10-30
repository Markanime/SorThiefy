
using UnityEngine;

public class Blink : MonoBehaviour {
	private Renderer myRenderer;
	[SerializeField]
	private float time = 0.1f;
	private float elapsedTime = 0;

	void Start () {
		myRenderer = GetComponent<Renderer>();
	}
	
	void Update () {
		elapsedTime +=Time.deltaTime;
		if (elapsedTime > time)
		{
			myRenderer.enabled = !myRenderer.enabled;
			elapsedTime = 0;
		}
	}
	private void OnDisable()
    {
		myRenderer.enabled = true;
		elapsedTime = 0;
	}
}
