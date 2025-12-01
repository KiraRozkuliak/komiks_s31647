using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("Movement speed on Y axis")]
    public float moveSpeed = 5f; 


    [Header("Y axis movement limits (optional)")]
    public bool useBounds = false; 
  

    public float minY = -5f; 


    public float maxY = 5f;  
    

    void Update()
    {
        float vertical = 0f;


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            vertical = 1f;
        }
   
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            vertical = -1f;
        }

  
        Vector3 move = new Vector3(0f, vertical, 0f) * moveSpeed * Time.deltaTime;

  
        transform.position += move;

    
        if (useBounds)
        {
            Vector3 pos = transform.position;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            transform.position = pos;
        }
    }
}

