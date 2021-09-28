using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    private float inputX;
    private float inputY;
    
    [SerializeField] 
    private float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            inputX = Input.GetAxisRaw("Horizontal");
            inputY = Input.GetAxisRaw("Vertical");
            
            if (inputX != 0 || inputY != 0)
            {
                Vector2 targetPos = transform.position;
                targetPos.x += inputX;
                targetPos.y += inputY;
                
                StartCoroutine(Move(targetPos));
            }
        }
    }

    IEnumerator Move(Vector2 targetPos)
    {
        isMoving = true;
        while ((targetPos - (Vector2)transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        } 
        transform.position = targetPos;
        isMoving = false;
    }
}
