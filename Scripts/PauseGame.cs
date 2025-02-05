using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenuUI; // Панель паузы
    private bool isPaused = false;

    void Update()
    {
        // Включаем/выключаем паузу по Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Показываем меню
        Time.timeScale = 0f; // Останавливаем время
        isPaused = true;
        Cursor.lockState = CursorLockMode.None; // Разблокируем курсор
        Cursor.visible = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Прячем меню
        Time.timeScale = 1f; // Возобновляем время
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked; // Прячем курсор
        Cursor.visible = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Возвращаем нормальное время
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Перезапускаем сцену
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f; // Возвращаем нормальное время
        SceneManager.LoadScene("MainMenu"); // Загружаем главную сцену (переименуй под свою!)
    }
}