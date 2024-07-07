using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LiftUsage : MonoBehaviour
{
    public bool Enabled;
    public Text Modultxt;
    private Renderer ren;
    public GameObject LiftPanel;

    void Start()
    {
        Enabled = false;
        ren = GetComponent<Renderer>();

        if (LiftPanel != null)
        {
            LiftPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Enabled && Input.GetKeyDown(KeyCode.E))
        {
            if (LiftPanel != null)
            {
                LiftPanel.SetActive(!LiftPanel.activeSelf);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Enabled = true;
            if (Modultxt != null)
            {
                Modultxt.text = "Press the \"E\" Button";
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Enabled = false;
            if (Modultxt != null)
            {
                Modultxt.text = string.Empty;
            }
        }
    }
}
