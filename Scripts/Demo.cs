using UnityEngine;

public class Demo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        QuestJournal journal = new QuestJournal(10);
        Quest q1 = new Quest("Выйти на улицу", 10);
        journal.TakeQuest(q1);
        Debug.Log(q1);

        Quest q2 = new Quest("Сделать вдох", 50);
        journal.TakeQuest(q2);
        Debug.Log(q2);

        Quest q3 = new Quest("Присесть", 100);
        journal.TakeQuest(q3);
        Debug.Log(q3);

        Quest q4 = new Quest("Дотронуться до травы", 10000);
        journal.TakeQuest(q4);
        Debug.Log(q4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
