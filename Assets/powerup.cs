using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
   
    void Update()
    {
        transform.Rotate(Vector3.up * 120 * Time.deltaTime);
    }
}
