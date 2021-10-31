using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {
	public Animator slides;
	public GameObject PressEnterToContinue;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Submit") && PressEnterToContinue.activeInHierarchy)
        {
			PressEnterToContinue.SetActive(false);
			slides.SetTrigger("next");
        }
	}

	public void EnableContinue()
    {
		PressEnterToContinue.SetActive(true);
    }

	public void LoadGame()
    {
		SceneManager.LoadScene("game");
		ServiceLocator.GetService<MusicSevice>().Play();
    }
}