using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class Snake : MonoBehaviour
{
    bool _ateFood = false;
   
    public GameObject _snakeBodySegment; 
    List<Transform> _snakeBody = new List<Transform>();
    Vector3 headPosition;

    int score = 0;
    public bool gameOver = false;

    float snakeSpeed = 4;

    LevelController levelControl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            gameOver = true;
        }

        if (collision.gameObject.tag == "Food" && !gameOver)
        {
            _ateFood = true;
            score++;
            

        }
         
        else if (collision.gameObject.tag == "SnakeBody" && score > 0 && !gameOver)

        {          
                score--; 
        }
        
    }

    
    private void snakeMoveHelper()
    {
        // initialize tail piece off screen because it is easier to deal with
        Vector3 delta = new Vector3(0, 20f); 
        headPosition = _snakeBody.Last().position;
        headPosition += delta;

        snakeMove(); 

        if (_ateFood)
        {
            GameObject segment = (GameObject)Instantiate(_snakeBodySegment, headPosition, Quaternion.identity);
            _snakeBody.Add(segment.transform);
            _ateFood = false; 
        }
       
    }

    private void FixedUpdate()
    {
        for (int i = _snakeBody.Count - 1; i > 0; i--)
         {
            if(!gameOver)
            {
                _snakeBody[i].position = _snakeBody[i - 1].position;
                _snakeBody[i].rotation = _snakeBody[i - 1].rotation;
            }
                
        }
        
    }

    private void snakeMove()
    {

        if (Input.GetKey(KeyCode.DownArrow))
        {

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, snakeSpeed* -1.0f);
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = -90;
            transform.rotation = Quaternion.Euler(rotationVector); 

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, snakeSpeed * 1.0f);
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 90;
            transform.rotation = Quaternion.Euler(rotationVector);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(snakeSpeed * -1.0f, 0.0f);
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 180;
            transform.rotation = Quaternion.Euler(rotationVector);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(snakeSpeed * 1.0f, 0.0f);
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 0;
            transform.rotation = Quaternion.Euler(rotationVector);
            
        }

    }
    private void Awake()
    {
        levelControl = FindObjectOfType<LevelController>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        _snakeBody.Add(this.transform); // snake head at front of the list
        headPosition = _snakeBody.Last().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) // prevents snake movement if game over
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        snakeMoveHelper();
        levelControl.setGameStatus(gameOver);
        levelControl._finalScore = score; 
        
    }
}
