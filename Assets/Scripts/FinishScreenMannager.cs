using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FinishScreenMannager : MonoBehaviour
{
    public Button startGameButon;
    public Button returnMenuButon;
    private void Start()
    {
        startGameButon.onClick.AddListener(RestarGame);
        returnMenuButon.onClick.AddListener(ReturnMenu);
    }
    public void RestarGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
