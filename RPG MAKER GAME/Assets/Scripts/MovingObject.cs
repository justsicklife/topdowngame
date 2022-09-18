using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{

    public float speed;
    private Vector3 vector;

    public float runSpeed;
    private float applyRunSpeed;
    private bool applyRunFlag = false;

    public int walkCount;
    private int currentWalkCount;

    private bool canMove = true;

    void Start()
    {
        
    }

    IEnumerator MoveCoroutine()
    {

        if(Input.GetKey(KeyCode.LeftShift))
            {
                applyRunSpeed = runSpeed;
                applyRunFlag = true;
            }
            else 
            {
                applyRunSpeed = 0;
                applyRunFlag = false;
            }

            vector.Set(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0);

            while(currentWalkCount < walkCount)
            {
                if(vector.x != 0)
                {
                    transform.Translate(vector.x * (speed + applyRunSpeed) ,0,0);
                }
                else if (vector.y != 0) 
                {
                    transform.Translate(0 ,vector.y *(speed + applyRunSpeed),0);
                }

                if(applyRunFlag) 
                    currentWalkCount+=1;
                currentWalkCount += 1; 
                yield return new WaitForSeconds(0.01f);
            }
        currentWalkCount = 0;
        
        canMove = true;
    }

    void Update()
    { 
        if (canMove)
        {
            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                canMove=false;
                StartCoroutine(MoveCoroutine());
            }
        }
    }
}
