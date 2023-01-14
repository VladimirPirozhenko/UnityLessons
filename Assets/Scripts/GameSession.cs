using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    [SerializeField] private PlayerController currentPlayer;
  //  [SerializeField] private Scoreboard scoreboard;
    public static GameSession Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseSession(bool isPaused)
    {
        Time.timeScale = isPaused ? 0 : 1;
    }
    public void RestartSession()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        PauseSession(false);
    }
}
