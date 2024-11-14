using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ManagerMenu : MonoBehaviour
{
    public Button startGameButon;
    public Button returnMenuButon;
    public Button returnMenuButon2;
    public Button tutorialButon;
    public Button creditsButon;
    public GameObject panelMain;
    public GameObject panelTutorial;
    public GameObject panelCredits;
    void Start()
    {
        startGameButon.onClick.AddListener(StartGame);
        returnMenuButon.onClick.AddListener(ReturnButon);
        returnMenuButon2.onClick.AddListener(ReturnButon);
        tutorialButon.onClick.AddListener(TutorialButon);
        creditsButon.onClick.AddListener (CreditsButon);
    }
    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    private void TutorialButon()
    {
        panelTutorial.SetActive(true);
        panelCredits.SetActive(false);
        panelMain.SetActive(false);
    }
    private void ReturnButon()
    {
        panelTutorial.SetActive(false);
        panelCredits.SetActive(false);
        panelMain.SetActive(true);
    }
    private void CreditsButon()
    {
        panelTutorial.SetActive(false);
        panelCredits.SetActive(true);
        panelMain.SetActive(false);
    }
}
