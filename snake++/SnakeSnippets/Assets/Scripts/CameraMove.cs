using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject snake;
    public float interpSpeed;
    private Vector3 targetPos; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        targetPos = new Vector3(snake.transform.position.x, snake.transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, interpSpeed); 
    }
}
