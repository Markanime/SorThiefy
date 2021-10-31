using UnityEngine;
using UnityEngine.UI;

public class CanvasScoreText : MonoBehaviour {
	[SerializeField]
	private string template = "Robbed Money:{0}\nTotal Robbed:{1}";
	[SerializeField]
	private NunScore nunScore;
	[SerializeField]
	private Text text;
	int totalScore = 0;
	void Start () {
		totalScore = ServiceLocator.GetService<LevelService>().GetTotalScore();
		nunScore.OnScoreChanged.AddListener(Print);
		Print();
	}

	void Print()
    {
		int current = nunScore.GetScore();
		text.text = string.Format(template, current, totalScore+ current);
    }
	
}
