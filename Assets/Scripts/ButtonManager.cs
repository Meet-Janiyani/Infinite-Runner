using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
