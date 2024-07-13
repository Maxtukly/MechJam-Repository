using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectronicsPanelManager : MonoBehaviour
{
    public GameObject panel; // Панель, яку потрібно відображати/сховувати
    public Image batteryIndicator; // Індикатор батареї
    public Button[] chargeButtons; // Масив кнопок для зарядки
    public Button resetButton; // Кнопка для скидання заряду

    private float batteryCharge = 0f; // Заряд батареї
    private const float maxBatteryCharge = 80f; // Максимальний заряд батареї

    private void Start()
    {
        // Встановлюємо початкові стани кнопок
        foreach (Button button in chargeButtons)
        {
            button.onClick.AddListener(() => ChargeBattery(10f));
        }
        resetButton.onClick.AddListener(ResetBattery);

        // Make sure panel is initially inactive
        if (panel != null)
        {
            panel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Panel GameObject is not assigned in the Inspector.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (panel != null)
            {
                panel.SetActive(!panel.activeSelf);
            }
            else
            {
                Debug.LogWarning("Panel GameObject is not assigned in the Inspector.");
            }
        }

        UpdatePanelStatus();
    }

    // Метод для заряджання батареї
    public void ChargeBattery(float amount)
    {
        batteryCharge += amount;
        if (batteryCharge > maxBatteryCharge)
        {
            batteryCharge = maxBatteryCharge; // Максимум 80
        }
    }

    // Метод для скидання батареї
    private void ResetBattery()
    {
        batteryCharge = 0f;
    }

    // Метод для оновлення стану панелі
    private void UpdatePanelStatus()
    {
        // Оновлюємо кольори індикатора батареї і кнопок
        if (batteryCharge >= maxBatteryCharge)
        {
            batteryIndicator.color = Color.cyan; // Синій при максимальному заряді
            foreach (Button button in chargeButtons)
            {
                button.GetComponent<Image>().color = Color.green; // Зелені кнопки при максимальному заряді
            }
        }
        else
        {
            batteryIndicator.color = Color.red; // Червоний при недостатньому заряді
            foreach (Button button in chargeButtons)
            {
                button.GetComponent<Image>().color = Color.red; // Білий колір кнопок
            }
        }
    }
}
