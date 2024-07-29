using UnityEngine;
using UnityEngine.SceneManagement;

public class SetOnPause : MonoBehaviour
{
    private bool isPaused;
    public GameObject pp;

    private void Start()
    {
        isPaused = false;
    }

    public void SetPause()
    {
        if (!isPaused)
        {
            pp.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
        else if (isPaused)
        {
            pp.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    public void OnPause()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
            pp.SetActive(false);
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0;
            pp.SetActive(true);
        }
    }
    public void Сontinue()
    {
        pp.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void GoToMenu()
    {
        Time.timeScale = 1;
        pp.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
