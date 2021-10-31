using UnityEngine;

[RequireComponent(typeof(NunController))]
public class NunHealth : MonoBehaviour {
	[SerializeField]
	private AudioSource[] damageSound;
	[SerializeField]
	private AudioSource[] deadSound;
	[SerializeField]
	private Animator damageAnimator;
	private float health = 100, nextDamage = 0, invencibleTime = 0;
	private Blink blink;
	private Collider2D col;
	void Start()
	{
		blink = GetComponentInChildren<Blink>();
		col = GetComponent<Collider2D>();
	}

	public void Damage(float damage)
	{
		nextDamage = damage;
	}

	void Update()
    {
		if (health <= 0)
		{
			blink.enabled = false;
			GetComponent<NunController>().enabled = false;
			damageAnimator.SetTrigger("die");
			col.enabled = false;
			foreach (var d in deadSound) { d.Play(); }
			ServiceLocator.GetService<LevelService>().GameOver();
			enabled = false;
			return;
		}
		if(invencibleTime <= 0 && nextDamage > 0)
        {
			damageAnimator.SetTrigger("damage");
			foreach (var d in damageSound) { d.Play(); }
			health -= nextDamage;
			invencibleTime = 1;
			blink.enabled = true;
        }
        else if(invencibleTime > 0)
        {
			nextDamage = 0;
			invencibleTime -=Time.deltaTime;
			if(invencibleTime <= 0) 
				blink.enabled = false;
        }
    }

}
