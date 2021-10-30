using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinArrow : MonoBehaviour {
	private Transform target;
	private GameObject arrow;
	private	bool activateArrow = false;
	private AvailableCoins availableCoins;
	void Start () {
		arrow = transform.GetChild(0).gameObject;
		arrow.SetActive(activateArrow);
		availableCoins = ServiceLocator.GetService<AvailableCoins>();
		availableCoins.OnCoinRemoved.AddListener( () => { activateArrow = false; arrow.SetActive(false); });
		StartCoroutine(VisibleCoins());
	}
	IEnumerator VisibleCoins()
    {
		yield return new WaitForEndOfFrame();
		List<Coin> coins = availableCoins.GetCoins();
		while (coins.Count >= 1)
		{
			yield return new WaitForSeconds(0.5f);
			if (coins.Count >= 1)
				CheckVisibility(coins);
		}
		activateArrow = false;
	}
	void CheckVisibility(List<Coin> coins)
    {
		if (coins.Count != 1)
		{
			foreach (var coin in coins)
			{
				var renderer = coin.GetComponent<Renderer>();
				if (renderer)
					if (renderer.isVisible)
					{
						activateArrow = false;
						return;
					}
			}
		}
		activateArrow = true;
		target = transform.GetNearest(coins).transform;
	}

	void Update () {
        if (target)
        {
			transform.LookAt2D(target.position);
			arrow.SetActive(activateArrow);
		}
	}
}
