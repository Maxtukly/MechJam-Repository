using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoordinatesChanger : MonoBehaviour
{
    public Text Lifttxt;
    public GameObject Player;
    public GameObject Exit;
    public GameObject Exit2;
    public GameObject Exit3;
    public GameObject Exit4;

    //    private bool IsInArea = false; 

    //    void Update()
    //    {
    //        if (IsInArea && Input.GetKeyDown(KeyCode.E))
    //        {
    //            Player.transform.position = Exit.transform.position;
    //        }
    //    }

    //    void OnTriggerEnter2D(Collider2D other)
    //    {
    //        if (other.CompareTag("Player"))
    //        {
    //            Lifttxt.text = "Press the \"E\" Button";
    //            IsInArea = true;
    //        }
    //    }

    //    void OnTriggerExit2D(Collider2D other)
    //    {
    //        if (other.CompareTag("Player"))
    //        {
    //            Lifttxt.text = "";
    //            IsInArea = false;
    //        }
    //    }
    public void Floor1()
    {
        Player.transform.position = Exit.transform.position;
    }
    public void Floor2()
    {
        Player.transform.position = Exit2.transform.position;
    }
    public void Floor3()
    {
        Player.transform.position = Exit3.transform.position;
    }
    public void Floor4()
    {
        Player.transform.position = Exit4.transform.position;
    }
}
