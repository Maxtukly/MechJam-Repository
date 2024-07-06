using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoordinatesChanger : MonoBehaviour
{
    public Text Lifttxt; 
    public GameObject Player; 
    public GameObject Exit; 

    private bool IsInArea = false; 

    void Update()
    {
        if (IsInArea && Input.GetKeyDown(KeyCode.E))
        {
            Player.transform.position = Exit.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Lifttxt.text = "Press the \"E\" Button";
            IsInArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Lifttxt.text = "";
            IsInArea = false;
        }
    }
}
