using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverScreen;

    public static Vector2 lastCheckpoint = new Vector2(-7,0);
    public static int numberOfCoin;
    public TextMeshProUGUI coinsText;

    private void Awake()
    {
        
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckpoint; 
        gameOver = false; 
    }


    // Update is called once per frame
    void Update()
    {
        coinsText.text = numberOfCoin.ToString(); 
        if (gameOver)
        {
            gameOverScreen.SetActive(true);
            
        }
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        numberOfCoin = 0;
    }
}
