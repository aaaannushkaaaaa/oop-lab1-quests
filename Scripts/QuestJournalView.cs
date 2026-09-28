using System;
using UnityEngine;

public class QuestJournalView : MonoBehaviour
{
    [SerializeField] private int maxActive = 10;
    public int Active => journal.Active;
    private QuestJournal journal;

    private void Start()
    {
        journal = new QuestJournal(maxActive);
    }
    private int questCounter = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            try
            {
                questCounter++;
                Quest quest = new Quest($"Квест {questCounter}", 10 * questCounter);
                journal.TakeQuest(quest);
                Debug.Log($"Взят квест: {quest}");
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            try
            {
                Quest[] active = journal.GetActiveQuests();
                if (active.Length == 0)
                {
                    Debug.Log("Нет активных квестов для сдачи");
                    return;
                }
                string id = active[0].Id;
                journal.CompleteQuest(id);
                Debug.Log($"Сдан квест: {id}");
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}

