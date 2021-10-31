using UnityEngine;
using UnityEngine.Events;
public class NunScore : MonoBehaviour {
	public UnityEvent OnScoreChanged;
	private int score;
	[SerializeField]
	private Animator winAnimation;

	void Start()
	{
		ServiceLocator.GetService<AvailableCoins>().OnAllCoinsRemoved.AddListener(Win);
	}
	

	private void Win()
    {
		GetComponent<NunController>().enabled = false;
		GetComponent<NunHealth>().enabled = false;
		winAnimation.SetTrigger("win");
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
