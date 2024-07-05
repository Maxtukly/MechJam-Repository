using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinatesChanger : MonoBehaviour
{
    public GameObject Player;
    public GameObject Entry;
    public GameObject Exit;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Entry"))
        {
            Player.transform.position = Exit.transform.position;
        }
    }
}
