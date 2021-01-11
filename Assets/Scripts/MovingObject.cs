using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{

    public float speed =0.001f;
    private Vector3 vector3;

    public float runSpeed = 0.001f;
    private float applyRunSpeed;
    private bool applyRunFlag=false;

    public int walkCount = 48;
    private int currentWalkCount;

    public Transform currentPos;
    

    // Start is called before the first frame update

    private bool canMove = true;

    IEnumerator MoveCoroutine()
    {
       
            if (Input.GetKey(KeyCode.LeftShift))
            {
                applyRunSpeed = runSpeed;
                applyRunFlag = true;
            }
            else
            {
                applyRunSpeed = 0;
            applyRunFlag = false;
        }

            vector3.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

        //while (currentWalkCount < walkCount)
        //{

        //    if (vector3.x != 0)
        //    {

        //        transform.Translate(vector3.x * (speed + applyRunSpeed) * walkCount, 0, 0);
        //    }
        //    else if (vector3.y != 0)
        //    {
        //        transform.Translate(0, vector3.y * (speed + applyRunSpeed) * walkCount, 0);
        //    }

        //    if(applyRunFlag)
        //    {
        //        currentWalkCount++;
        //    }

        //    currentWalkCount++;
        //    yield return new WaitForSeconds(0.01f);

        //}

        transform.Translate(Mathf.SmoothDamp())

        yield return new WaitForSeconds(1f);
        currentWalkCount = 0;
        canMove = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                canMove = false;
                StartCoroutine("MoveCoroutine");

            }
        }
    }
}
