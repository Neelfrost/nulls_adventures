using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void PlayButton()
    {
        GameObject.FindGameObjectWithTag("Transition").GetComponent<Transition>().LoadNextLevel();
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void LevelSelectButton(int Level)
    {
        GameObject.FindGameObjectWithTag("Transition").GetComponent<Transition>().LoadLevel(Level);
    }
}
