using UnityEngine;
using UnityEngine.UI;
using System;
public class ExitImage : MonoBehaviour {
	private Animator animator;
	private Action postAction;

	[SerializeField]
	private Image image;
	[SerializeField]
	private Text text;
	[SerializeField]
	private FinalScreen[] finalScreens;


	void Start () {
		animator = GetComponent<Animator>();
		ServiceLocator.RegisterService(this);
	}
	
	public void ShowImage(int score, Action postAction)
    {
		this.postAction = postAction;
		if (score > 0)
		{
			if (ServiceLocator.GetService<AvailableCoins>().GetCoins().Count == 0)
			{
				SetImage(1); //Steal everycoin
			}
			else
			{
				SetImage(2); //Steal some coin
			}
		}
		else if(score < 0)
        {
			SetImage(3); //GameOver;
		}
        else
        {
			SetImage(0); //No steal
        }

		animator.SetTrigger("play");
    }

	public void RunPostAction()
    {
		postAction.Invoke();
    }

	private void SetImage(int index)
    {
		image.sprite = finalScreens[index].frame;
		text.text = string.Format(finalScreens[index].text,"\n");
	}

	[Serializable]
	private struct FinalScreen
	{
		public Sprite frame;
		public string text;
	}


}
