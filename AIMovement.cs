using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float movementspeed = 20f;
    public float rotationspeed = 300f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationspeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationspeed);
        }
        if(isWalking == true)
        {
            rb.AddForce(transform.forward * movementspeed);
        }

        
    }

    IEnumerator Wander()
     {
            int rotationTime = Random.Range(1, 3);
            int rotateWait = Random.Range(1, 3);
            int rotateDirection = Random.Range(1, 2);
            int walkWait = Random.Range(1, 3);
            int WalkTime = Random.Range(1, 3);

            isWandering = true;

            yield return new WaitForSeconds(walkWait);

            isWalking = true;

            yield return new WaitForSeconds(WalkTime);

            isWalking = false;

            yield return new WaitForSeconds(rotateWait);

            if (rotateDirection == 1)
            {
                isRotatingLeft = true;
                yield return new WaitForSeconds(rotationTime);
                isRotatingLeft = false;
            }

            if (rotateDirection == 2)
            {
                isRotatingRight = true;
                yield return new WaitForSeconds(rotationTime);
               isRotatingRight = false;
            }

            isWandering = false;
     }
}
