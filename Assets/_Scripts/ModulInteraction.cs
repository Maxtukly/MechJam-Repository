using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ModulInteraction : MonoBehaviour
{
    public bool Enabled;
    public Text Modultxt;
    private Renderer ren;
    public GameObject Panel;
    public LayerMask player;

    void Start()
    {
        Enabled = false;
        ren = GetComponent<Renderer>();
    }

    void Update()
    {
        if(Physics2D.OverlapCircle(this.transform.position, 2, player))
        {
            Enabled = true;
            Modultxt.text = "Press the \"E\" Button for repair";
        }

        if (Enabled && Input.GetKeyDown(KeyCode.E))
        {
            Panel.active = !Panel.active;
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

    public void Interaction()
    {
        ren.material.SetColor("_Color", Color.blue);
        Invoke("EnergyCount", 3.0f);
    }
}
