using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AvailableCoins : MonoBehaviour {
    public UnityEvent OnCoinRemoved;
    public UnityEvent OnAllCoinsRemoved;
    public UnityEvent OnPanicMode;

    private List<Coin> coinList = new List<Coin>();

    void Awake()
    {
        ServiceLocator.RegisterService(this);
    }

    void Start() { 
        StartCoroutine(RegisterCoins());
    }

    IEnumerator RegisterCoins()
    {
        yield return new WaitForEndOfFrame();
        coinList = new List<Coin>(GameObject.FindObjectsOfType<Coin>());
    }

    public List<Coin> GetCoins()
    {
        return coinList;
    }

    public void RemoveCoin(Coin coin)
    {
        coinList.Remove(coin);
        OnCoinRemoved.Invoke();
        if(coinList.Count <= 0) 
            OnAllCoinsRemoved.Invoke();
        if (coinList.Count == 3)
            OnPanicMode.Invoke();
    }
}
