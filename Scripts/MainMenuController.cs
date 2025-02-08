using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;   // Панель главного меню
    public GameObject authorsPanel;    // Панель с информацией об авторах

    private void Start()
    {

            transform.Find("ContinueButton").gameObject.SetActive(true);
    }

    // Продолжить игру
    public void ContinueGame()
    {
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            string savedScene = PlayerPrefs.GetString("SavedScene");
            SceneManager.LoadScene(savedScene);
        }
    }

    // Новая игра
    public void NewGame()
    {
        PlayerPrefs.DeleteKey("SavedScene"); // Удаление старого сохранения
        SceneManager.LoadScene("GameScene"); // Загружаем новую игру
    }

    // Показать панель с авторами
    public void ShowAuthors()
    {
        mainMenuPanel.SetActive(false);
        authorsPanel.SetActive(true);
    }

    // Вернуться в главное меню с панели авторов
    public void BackToMenu()
    {
        authorsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    // Выйти из игры
    public void QuitGame()
    {
        Debug.Log("Выход из игры...");
        Application.Quit();
    }
}