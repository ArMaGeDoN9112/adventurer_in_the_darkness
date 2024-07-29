using UnityEngine;

public class MainMenuButtonsHandler : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _levelsMenu;
    [SerializeField] private GameObject _optionsMenu;


    public void ShowLevelMenu()
    {
        _mainMenu.SetActive(false);
        _levelsMenu.SetActive(true);
    }

    public void ShowOptions()
    {
        _mainMenu.SetActive(false);
        _optionsMenu.SetActive(true);
    }

    public void Quit() => Application.Quit();
}
