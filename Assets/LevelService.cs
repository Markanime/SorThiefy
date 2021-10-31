using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelService : MonoBehaviour {
    private int level = 0;
    private int totalScore = 0;

    public int GetLevel()
    {
        return level;
    }
    public int GetTotalScore()
    {
        return totalScore;
    }

    public void ResetTotalScore()
    {
        totalScore = 0;
    }

    public void NextLevel(int score)
    {
        if (score > 0)
            level++;
        totalScore += score;
        ServiceLocator.GetService<ExitImage>().ShowImage(score, () =>
         {
             SceneManager.LoadScene("game");
         });
    
    }

    public void GameOver()
    {
        ServiceLocator.GetService<ExitImage>().ShowImage(-1, () =>
        {
            SceneManager.LoadScene("menu");
        });
    }

    void Awake()
    {
     
        if (!ServiceLocator.HasService<LevelService>())
        {
            DontDestroyOnLoad(this.gameObject);
            ServiceLocator.RegisterService(this);
        }
        else
            Destroy(gameObject);
    }

}
