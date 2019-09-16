using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    [SerializeField]
    GameObject CameraMotor;

    //Основное описание персонажа

    [SerializeField]
    string Characker_Name; //Имя нпц
    [SerializeField]
    int Age; //Возраст 
    [SerializeField]
    string Gender; // Пол

    [SerializeField]
    GameObject Position_House; // дом
  

    //Описание характеристик

    double HealPoint; //Жизни
    int Strength; //Сила
    int Agility; //Ловкость
    int Endurance; //Выносливость
    double Stamina; //Запас выносливости

    //Профессия
    string Kind_of_Activity; // Вид деятельности
    [SerializeField]
    GameObject Work = null; //Место дислакации
    int Profession_Level=5; // Уровень професии 
    double Professional_Experience; // Текущий опыт професии 

    //Дела семейные

    GameObject[] Spouse; //Супруг
    GameObject[] Children; //Дети

    public float Time_Jobs = 100f;

    // Start is called before the first frame update
    void Start()
    {
        CameraMotor = GameObject.FindGameObjectWithTag("CameraMotor");
    }

    // Update is called once per frame
    void Update()
    {
        if(Work==null)
        {
            if (Time_Jobs <= 0)
            {
                jobs();
            }
            else
            {
                Time_Jobs -= Time.deltaTime;
            }

        }
    }

    public void jobs()
    {
        Work = CameraMotor.GetComponent<WorkForAi>().Work_Searches(Profession_Level,Position_House);
        if (Work == null)
            Time_Jobs = 500f;
    }
}
