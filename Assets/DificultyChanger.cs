using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultyChanger : MonoBehaviour {
	[SerializeField]
	private EnemyMove[] enemies;

	void Start() {
		float dificulty = ServiceLocator.GetService<LevelService>().GetLevel();

		float increaseLevel = dificulty > enemies.Length ? (dificulty - enemies.Length + 1) / 2 : 1;
		for (int i = 0; i < enemies.Length; i++)
		{
			enemies[i].gameObject.SetActive(i+1 <= dificulty);
			enemies[i].speed = enemies[i].speed * increaseLevel;
		}
		ServiceLocator.GetService<AvailableCoins>().OnPanicMode.AddListener(PanicMode);
	}

	void PanicMode()
    {
		for (int i = 0; i < enemies.Length; i++)
			enemies[i].speed = enemies[i].speed * 3;
	}

	
}
