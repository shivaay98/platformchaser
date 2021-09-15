using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float speed;

    private Rigidbody m_rb;
    private GameObject platform;
    private float platformY;
    private float speedmod;
    public Camera followcam;
    private Vector3 campos;
    private void Awake()
    {
        GameObject go = new GameObject();
        go.name = "circle";

        go.transform.parent = transform;

        m_rb = GetComponent<Rigidbody>();
        platformY = 0;
        speedmod = 1;
        campos = followcam.transform.position - m_rb.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");


        Vector3 playerpos = m_rb.position;
        Vector3 movement = new Vector3(horizontalinput, 0, verticalinput).normalized;

        if (movement == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
        if (platform != null)
        {
            playerpos.y = platform.transform.position.y + platformY;
        }




        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);
        m_rb.MovePosition(playerpos + movement * speedmod * speed * Time.fixedDeltaTime);
        m_rb.MoveRotation(targetRotation);

    }
    private void LateUpdate()
    {
        followcam.transform.position = m_rb.position + campos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("powerup"))
        {
            Destroy(collision.gameObject);
            speedmod = 2;
            StartCoroutine(bonusspeedcountdown());
        }
        if(collision.gameObject.CompareTag("enemy")&& speedmod>1)
        {
        Rigidbody enemyrb = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayfromplayer = collision.transform.position - transform.position;
        enemyrb.AddForce(awayfromplayer * 30.0f, ForceMode.Impulse);
        }

    }
    private IEnumerator bonusspeedcountdown()
        {
            yield return new WaitForSeconds(3.0f);
            speedmod = 1;
        }


    


    private IEnumerator BonusSpeed()
    {
        yield return new WaitForSeconds(3.0f);
        speedmod = 1;
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("platform"))
        {
            platform = other.gameObject;
            platformY = transform.position.y - platform.transform.position.y;

        }
       
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("platform"))
        {
            platform = null;
            platformY = 0;
        }
    }



}
