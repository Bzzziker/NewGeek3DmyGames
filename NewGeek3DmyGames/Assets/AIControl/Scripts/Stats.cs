using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //Основное описание персонажа

    [SerializeField]
    string Characker_Name; //Имя нпц
    [SerializeField]
    int Age; //Возраст 
    [SerializeField]
    string Gender; // Пол
    string _Position; //
  

    //Описание характеристик

    double HealPoint; //Жизни
    int Strength; //Сила
    int Agility; //Ловкость
    int Endurance; //Выносливость
    double Stamina; //Запас выносливости

    //Профессия
    string Kind_of_Activity; // Вид деятельности
    GameObject Location = null; //Место дислакации
    int Profession_Level; // Уровень професии 
    double Professional_Experience; // Текущий опыт професии 

    //Дела семейные

    GameObject[] Spouse; //Супруг
    GameObject[] Children; //Дети
     


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
