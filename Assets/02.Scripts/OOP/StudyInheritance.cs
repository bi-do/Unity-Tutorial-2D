using System.Collections.Generic;
using UnityEngine;

public class StudyInheritance : MonoBehaviour
{
    public List<Person> persons = new List<Person>();

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Student student = new Student();
            Soldier soldier = new Soldier();

            this.persons.Add(student);
            this.persons.Add(soldier);
        }
    }

    public void AllMove()
    {
        foreach (Person element in persons)
        {
            element.Walk();
        }
    }
}