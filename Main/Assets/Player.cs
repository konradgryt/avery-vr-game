using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    const int MAX_LIVES = 10;
    int currLives;

    static Player _instance;

    public static Player GetInstance()
    {
        if(_instance == null)
            _instance = FindObjectOfType(typeof(Player)) as Player;

        return _instance;
    } 

    private void Start()
    {
        currLives = MAX_LIVES;
    }

    private void LateUpdate()
    {
        if (currLives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
            currLives--;
    }

    public int Lives()
    {
        return currLives;
    }

}
