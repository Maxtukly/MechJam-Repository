using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class FightManager : MonoBehaviour
{

    [SerializeField] float fightTime;
    [SerializeField] float casualtiesTime;
    [SerializeField] float mechHealth;
    [SerializeField] GameObject wonPanel;
    [SerializeField] GameObject losePanel;
    float casualtiesTimer;
    [SerializeField] TextMeshProUGUI timerText;
    public List<GameObject> modules = new List<GameObject>();
    public Dictionary<string, int> mechModules = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        casualtiesTimer = casualtiesTime;
        mechModules.Add("Motors", 0);
        mechModules.Add("Pumps", 0);
        mechModules.Add("Electronics", 0);

        modules = GameObject.FindGameObjectsWithTag("Module").ToList<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mechHealth <= 0)
        {
            losePanel.active = true;
            Time.timeScale = 0;
        }    
        if(fightTime > 0)
        {

            fightTime -= Time.deltaTime;

            if(casualtiesTimer > 0)
            {
                casualtiesTimer -= Time.deltaTime;
            }
            if(casualtiesTimer < 0)
            {
                casualtiesTimer = casualtiesTime;
                BreakDown();
            }
        }
        if(fightTime <= 0)
        {
            fightTime = 0;
            wonPanel.active = true;
            Time.timeScale = 0;
        }

        int minutes = Mathf.FloorToInt(fightTime / 60);
        int seconds = Mathf.FloorToInt(fightTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    void BreakDown()
    {
        int damage = Random.Range(1, 3);
        int mechdamage = Random.Range(10, 20);
        mechHealth -= mechdamage - mechModules["Motors"];
        for (int i = 0; i < damage; i++)
        {
            int module = Random.Range(0, modules.Count - 1);
            modules[module].GetComponent<ModulInteraction>().GoBoom();
        }
    }

    public void RepairModule(string type)
    {
        mechModules[type] += 1;
    }

    public void BreakModule(string type)
    {
        mechModules[type] -= 1;
    }
}
