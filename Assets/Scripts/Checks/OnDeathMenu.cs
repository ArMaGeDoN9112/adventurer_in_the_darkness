using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDeathMenu : MonoBehaviour
{
    [SerializeField] private float _deathHeight;
    public GameObject menu;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.OnDeath += EnableMenu;
    }

    private void OnDisable()
    {
        _health.OnDeath -= EnableMenu;
    }

    private void Update()
    {
        if (transform.position.y < _deathHeight)
        {
            EnableMenu();
        }
    }

    private void EnableMenu()
    {
        menu.SetActive(true);
    }

    public void Respawn()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(GameManager.Instance.CurrentLevelIndex + 1);
    }
    public void GoToMenu()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
