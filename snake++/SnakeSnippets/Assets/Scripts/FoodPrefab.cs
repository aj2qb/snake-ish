using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPrefab : MonoBehaviour
{
    Vector3 snakeHeadPosition; 
    float x;
    float y;
    //int whichColor; 

    private void spawnFood(FoodPrefab piece)
    {
        x = Random.Range(-14.0f, 14.0f);
        y = Random.Range(-6.9f, 6.9f);
        Vector3 foodLocation = new Vector3(x, y, 0);

        while (snakeHeadPosition == foodLocation) // trying to prevent food to spawn on snake head
        {
            x = Random.Range(-14.0f, 14.0f);
            y = Random.Range(-6.9f, 6.9f);
            foodLocation = new Vector3(x, y, 0);
        }

        // Something is wrong with Unity's Sprite Renderer since color won't udpdate during runtime... 
        // Revisit later with unity update to see if problem is solved
        //whichColor = (int) Mathf.Round(Random.Range(0, 3.4f)); // Inclusive min and max

        /* switch (whichColor)
         {
             case 0:
                 piece.GetComponent<SpriteRenderer>().color = new Color(255, 51, 204); // pink 
                 piece.gameObject.transform.position = foodLocation;
                 piece.gameObject.SetActive(true);
                 print("PINK");
                 break;

             case 1:
                 piece.GetComponent<SpriteRenderer>().color = new Color(60, 227, 37); // green 
                 piece.gameObject.transform.position = foodLocation;
                 piece.gameObject.SetActive(true);
                 print("GREEN");

                 break;
             case 2:
                 piece.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255); // navy
                 piece.gameObject.transform.position = foodLocation;
                 piece.gameObject.SetActive(true);
                 print("NAVY");

                 break;

             case 3:
                 piece.GetComponent<SpriteRenderer>().color = new Color(92, 228, 188); // teal 
                 piece.gameObject.transform.position = foodLocation;
                 piece.gameObject.SetActive(true);
                 print("TEAL");

                 break;
         }*/


        //print(whichColor); 
        
        piece.gameObject.transform.position = foodLocation;
        piece.gameObject.SetActive(true);
        
        //print("END" + whichColor); 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "SnakeHead")
        {
            snakeHeadPosition = collision.gameObject.transform.position;

            gameObject.SetActive(false);


            spawnFood(this);
            

        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
