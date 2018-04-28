using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    
    public enum MenuStates { Main,Settings};
    public MenuStates CurrentState;
    public GameObject mainMenu,settingsMenu;
    public string GameDifficulty="Easy";
	float time;
    void Awake()
    {
        CurrentState = MenuStates.Main;
    }
    // Use this for initialization
    
	void Start () {
		time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        switch (CurrentState)
        {
            case MenuStates.Main:
                mainMenu.SetActive(true);
                settingsMenu.SetActive(false);
                break;

            case MenuStates.Settings:
                settingsMenu.SetActive(true);
                mainMenu.SetActive(false);
                break;
        }

	}
    
    public void OnSettings()
    {
        Debug.Log("you pressed Settings");
        CurrentState = MenuStates.Settings; 
    }
    public void OnBackToMainMenu()
    {
        Debug.Log("you pressed Main Menu");
        CurrentState = MenuStates.Main;
    }
    public void OnEasy()
    {
        GameDifficulty = "Easy";
        Debug.Log("Game is setted to be "+GameDifficulty);
    }
    public void OnHard()
    {
        GameDifficulty = "Hard";
        Debug.Log("Game is setted to be " + GameDifficulty);

    }
    public void NewGameBtn(string newGamelevel)
    {
		SceneManager.LoadScene("videoscene");
        //SceneManager.LoadScene("lastproject");
    }
    public void OnExit()
    {
        Application.Quit();
    }
    
}
