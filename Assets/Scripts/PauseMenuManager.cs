using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI;  // Assign the Panel GameObject here
    public GameObject player;       // Assign the player GameObject here
    public GameObject ordi;         // Assign the ordi GameObject here
    public Ball ball;               // Assign the ball GameObject here

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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

    public void Resume()
    {
        Debug.Log("Resuming game...");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        EnableGameObjects();
    }

    public void Pause()
    {
        Debug.Log("Pausing game...");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        DisableGameObjects();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f; // Ensure the time scale is reset to normal
        SceneManager.LoadScene("Menu");
    }

    private void DisableGameObjects()
    {
        player.GetComponent<Player>().DisableControls();
        ordi.GetComponent<Player>().DisableControls();
        ball.StopMovement();
    }

    private void EnableGameObjects()
    {
        player.GetComponent<Player>().EnableControls();
        ordi.GetComponent<Player>().EnableControls();
        ball.AddStartingForce();
    }
}
