using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    private float traveldist = 0;
    private float maxdist = 15.0f;
    private float speed = 5.0f;
    private Rigidbody rb;
    private Coroutine reversecoroutine;

    private IEnumerator Start()
    {
        rb = GetComponent<Rigidbody>();
        enabled = false;
        yield return new WaitForSeconds(3.0f);
        enabled = true;
    }

    void FixedUpdate()
    {
        
        if(traveldist>=maxdist)
        {
            if(reversecoroutine==null)
            {
                reversecoroutine = StartCoroutine("reverseelevator");

            }
        }else
        {
            float distancestep = speed * Time.fixedDeltaTime;
            traveldist += Mathf.Abs(distancestep);
            Vector3 platformpos = rb.position;
            platformpos.y += distancestep;

            rb.MovePosition(platformpos);

        }
    }
    private IEnumerator reverseelevator()
    {
        yield return new WaitForSeconds(3.0f);

        traveldist = 0;
        speed = -speed;
        reversecoroutine = null;    
    }

    
}

