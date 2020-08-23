using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void PlayButton()
    {
        GameManager.Instance.LoadNext();
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void LevelSelectButton(int Level)
    {
        GameManager.Instance.LoadScene(Level);
    }
}
