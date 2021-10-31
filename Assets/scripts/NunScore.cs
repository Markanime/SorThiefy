using UnityEngine;
using UnityEngine.Events;
public class NunScore : MonoBehaviour {
	public UnityEvent OnScoreChanged;
	private int score;
	[SerializeField]
	private Animator winAnimation;
	[SerializeField]
	private AudioSource[] winSound;
	void Start()
	{
		ServiceLocator.GetService<AvailableCoins>().OnAllCoinsRemoved.AddListener(Win);
	}
	

	private void Win()
    {
		GetComponent<NunController>().enabled = false;
		GetComponent<NunHealth>().enabled = false;
		winAnimation.SetTrigger("win");
		foreach (var d in winSound) { d.Play(); }
		ServiceLocator.GetService<LevelService>().NextLevel(score);
	}
	public void AddScore(int score)
	{
		this.score += score;
		OnScoreChanged.Invoke();
	}

	public int GetScore()
    {
		return score;
    }
}
