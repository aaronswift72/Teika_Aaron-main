using System.Runtime.InteropServices;
using UnityEngine;

public class BorderBehavior : MonoBehaviour
{
    public static BorderBehavior instance;

    public float timeOut;
    public float timeStart;
    public GameObject gameOver;
    public bool isGameOver;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        gameOver.SetActive(false);
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fruit"))
        {
            timeStart = Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fruit"))
        {
            float currentTime = Time.time;
            float timeThusFar = currentTime - timeStart;
            if(timeThusFar > timeOut)
            {
                gameOver.SetActive(true);
                print("Game over");
                isGameOver = true;
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fruit"))
        {
        }
    }

    public bool callIsGameOver()
    {
        return isGameOver;
    }
}
