using System.Runtime.InteropServices;
using UnityEngine;

    //Merge Order: Cherry > Strawberry > Grape > Lemon > Orange > Apple > Pear > Banana > Watermelon > Pineapple

public class FruitBehavior : MonoBehaviour
{
    public GameObject[] fruits;
    public int fruitType;
    
    // public float timeOut;
    // public float timeStart;

void Start()
{
    fruits = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().fruits;
}

private void OnCollisionEnter2D(Collision2D other)
{
    if (other.gameObject.CompareTag("fruit"))
    {
        int otherType = other.gameObject.GetComponent<FruitBehavior>().fruitType;
        if (otherType == fruitType && fruitType < fruits.Length - 1)
        {
            if (gameObject.transform.position.x < other.transform.position.x
                || gameObject.transform.position.x == other.transform.position.x
                && gameObject.transform.position.y >= other.gameObject.transform.position.y)
                {
                    //Create merged fruit
                    int choice = fruitType + 1;
                    GameObject currentFruit = Instantiate(fruits[choice], Vector3.Lerp(gameObject.transform.position, other.gameObject.transform.position, 0.5f), Quaternion.identity);
                    currentFruit.GetComponent<Collider2D>().enabled = true;
                    currentFruit.GetComponent<Rigidbody2D>().gravityScale = 1.0f;

                    //Destroy objects
                    Destroy (other.gameObject);
                    Destroy (gameObject);
                }
        }
    }
}

    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("TB"))
    //     {
    //         timeStart = Time.time;
    //     }
    // }

    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("TB"))
    //     {
    //         float currentTime = Time.time;
    //         float timeThusFar = currentTime - timeStart;
    //         if(timeThusFar > timeOut)
    //         {

    //             print("Game over");
    //         }
    //     }
        
    // }
    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("TB"))
    //     {
    //         timeStart = 0.0f;
    //     }
    // }
}
