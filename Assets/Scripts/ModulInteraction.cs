using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ModulInteraction : MonoBehaviour
{
    public bool Enabled;
    public Text Modultxt;
    private Renderer ren;

    void Start()
    {
        Enabled = false;
        ren = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Enabled && Input.GetKeyDown(KeyCode.E))
        {
            ren.material.SetColor("_Color", Color.blue);
            Invoke("EnergyCount", 3.0f);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Enabled = true;
            Modultxt.text = "Press the \"E\" Button";
        }
    }

    void EnergyCount()
    {
        Enabled = false;
        Modultxt.text = "";
    }
}