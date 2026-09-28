using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class QuestJournal
{
    private readonly int maxActive;

    private int active = 0;
    private int count = 0;
    private Quest[] quests;
    private static int questsTaken = 0;
    public static int QuestsTaken => questsTaken;
    public int Active => active;
    public QuestJournal(int maxActive)
    {
        quests = new Quest[4];
        this.maxActive = maxActive;
    }

    public void TakeQuest(Quest quest)
    {
        if (active < maxActive)
        {
            quest.Take();
            active += 1;
            if (count == quests.Length) Array.Resize(ref quests, quests.Length * 2);
            quests[count] = quest;
            count += 1;
            questsTaken += 1;
        }
        else throw new Exception("Слишком много активных квестов");
    }

    public Quest GetByID(string id)
    {
        foreach (Quest quest in quests)
        {
            if (quest == null) continue;
            if (quest.Id == id) return quest;
        }
        return null;
    }

    public void CompleteQuest(string id)
    {
        foreach (Quest quest in quests)
        {
            if (quest == null) continue;
            if (quest.Id == id){
                quest.Complete();
                active -= 1;
                break;
            }
        }
    }
    public int RewardSum()
    {
        int total = 0;
        foreach (Quest quest in quests)
        {
            if (quest == null) continue;
            if (quest.State == QuestState.Completed) total += quest.Reward;
        }
        return total;
    }

    public Quest[] GetActiveQuests()
    {
        Quest[] actives = new Quest[0];
        int counter = 0;
        foreach (Quest quest in quests)
        {
            if (quest == null) continue;
            if (quest.State == QuestState.Taken)
            {
                Array.Resize(ref actives, actives.Length + 1);
                actives[counter] = quest;
                counter++;
            }
        }
        return actives;
    }
}
