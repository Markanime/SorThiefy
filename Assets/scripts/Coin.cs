using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Coin : Touchable {
    public int Value;

	protected override void ReplyNun(NunController nun)
    {
        nun.GetComponent<NunScore>().AddScore(Value);
        ServiceLocator.GetService<AvailableCoins>().RemoveCoin(this);
        GetComponent<Animator>().SetTrigger("grab");
    }
}
