using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NunScore : MonoBehaviour {
	private int score;
	[SerializeField]
	private Animator winAnimation;

	void Start()
	{
		ServiceLocator.GetService<AvailableCoins>().OnAllCoinsRemoved.AddListener(()=> { 
			GetComponent<NunController>().enabled = false;
			winAnimation.SetTrigger("win"); });
	}

	public void AddScore(int score)
	{
		score += score;
	}

	public int GetScore()
    {
		return score;
    }
}
