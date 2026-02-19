using UnityEngine;
using UnityEngine.InputSystem;

    //Merge Order: Cherry > Strawberry > Grape > Lemon > Orange > Apple > Pear > Banana > Watermelon > Pineapple

public class PlayerBehavior : MonoBehaviour{
    
    public float speed;
    private GameObject currentFruit;
    public GameObject[] fruits;
    public float min;
    public float max;
    //public int[] numbers;
    
    public float offY = -0.6f;
    public float offset = 0f;
    public float currentTime = 0.0f;
    public float dropTime = 0.0f;
    public float dropCoolDown = 1f;
    public int move;
    public float enterTB = 0.0f;
    public float exitTB = 0.0f;
    public bool gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //startTime = 0.0f;
        move = 0; // 0 means you can move either way

    }
    // Update is called once per frame
    void Update(){
        gameOver = BorderBehavior.instance.callIsGameOver();
        currentTime = Time.time;
        offset = 0f;
        //int choice = Random.Range(27, 60);
        //print (choice);
        
        //fruit position below player
        if (currentFruit != null)
        {
            Vector3 playerPos = transform.position;
            Vector3 fruitOffset = new Vector3(0.0f, offY, 0.0f);
            currentFruit.transform.position = playerPos + fruitOffset * Time.deltaTime;
        }
        else
        {
            int choice = Random.Range(0, fruits.Length);
            currentFruit = Instantiate(fruits[choice], new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }
        //drop fruit with timer
        if (Keyboard.current.spaceKey.wasPressedThisFrame && currentTime >= dropTime + dropCoolDown && gameOver == false)
        {
            dropTime = currentTime;

            Rigidbody2D body = currentFruit.GetComponent<Rigidbody2D>();
            body.gravityScale = 1.0f;

            Collider2D collider = currentFruit.GetComponent<Collider2D>();
            collider.enabled = true;

            currentFruit = null;
        }
        
        // Keyboard movement of player
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed && move != 1)
        {
            offset = - speed;
        }
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed && move != 2)
        {
            offset = speed;
        }

        if (gameOver == false)
        {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x + offset;

            if (newPos.x > max)
            {
                newPos.x = max;
            }

            if (newPos.x < min)
            {
                newPos.x = min;
            }
            transform.position = newPos;
        }
        
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("LB"))
        {
            move = 1; // Cannot move left
        }
        if (other.gameObject.CompareTag("RB"))
        {
            move = 2; //Cannot move right
        }
    }

    private void OnCollisionExit2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("LB"))
        {
            move = 0; //Can move either way
        }
        if (other.gameObject.CompareTag("RB"))
        {

        }
    }
    
}