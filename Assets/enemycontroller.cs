using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontroller : MonoBehaviour
{
    private Rigidbody m_rb;
    private GameObject m_followtarget;
    public float speed;
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }


    void Start()
    {
        m_followtarget = GameObject.Find("player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movetowards = (m_followtarget.transform.position - transform.position).normalized;
        movetowards.y = 0;
        m_rb.AddForce(movetowards*speed);
        if(transform.position.y<=-15.0f)
        {
            Destroy(gameObject);
        }
    
    }
}
