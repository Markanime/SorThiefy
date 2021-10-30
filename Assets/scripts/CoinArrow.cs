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
			yield return new WaitForSeconds(2f);
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

	private Coin GetNearestCoin(Vector2 position,List<Coin> coins)
    {
		Coin current = coins[0];
		for (int i=1;i<coins.Count;i++)
        {
			var currentDistance = Vector2.Distance(current.transform.position, position);
			var newDistance = Vector2.Distance(coins[i].transform.position, position);
			if(currentDistance > newDistance)
            {
				current = coins[i];
            }
		}
		return current;
    }

	void Update () {
        if (target)
        {
			transform.LookAt2D(target.position);
			arrow.SetActive(activateArrow);
		}
	}
}
