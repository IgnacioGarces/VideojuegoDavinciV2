using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseScript : MonoBehaviour
{
    private bool on_pause;
    [SerializeField] private GameObject pause_menu;
    [SerializeField] private Button[] Buttons;
    private void Awake()
    {
        on_pause = false;
    }
    void Start()
    {
        InputManager.instance.pause += MenuState;
        Buttons[0].onClick.AddListener(GoToMainMenu);
        Buttons[1].onClick.AddListener(ExitGame);
        Buttons[2].onClick.AddListener(Continue);
    }
    private void MenuState()
    {
        if (!on_pause)
        {
            Pause();
        }
        else
        {
            Continue();
        }
    }
    private void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void ExitGame()
    {
        Application.Quit();
        Debug.Log("Funciona solo en build");
    }
    private void Continue()
    {
        Time.timeScale = 1.0f;
        pause_menu.SetActive(false);
        on_pause = false;
    }
    private void Pause()
    {
        Time.timeScale = 0.0f;
        pause_menu.SetActive(true);
        on_pause = true;
    }
}
