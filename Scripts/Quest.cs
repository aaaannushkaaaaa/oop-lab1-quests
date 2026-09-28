using System;
using System.Data.SqlTypes;
using UnityEngine;
public class Quest
{
    private readonly string name;
    private readonly string id;
    private QuestState state;
    private int reward;
    public string Id => id;
    public string Name => name;
    public QuestState State => state;
    public int Reward => reward;


    public Quest()
    {
        this.name = "Test";
        this.id = Guid.NewGuid().ToString();
        this.state = QuestState.Available;
        this.reward = 10;
    }

    public Quest(string name, int reward) : this()
    {
        if (reward <= 0)
        {
            throw new ArgumentException("Награда <= 0");
        }
        this.reward = reward;
        this.name = name;
    }

    public override string ToString()
    {
        return $"{this.name} {this.id} {this.state.ToString()} {this.reward.ToString()}";
    }

    public void Take()
    {
        if (this.state == QuestState.Available)
        {
            this.state = QuestState.Taken;
        }
        else throw new Exception("Квест не доступен");
    }

    public int Complete()
    {
        if (this.state == QuestState.Taken)
        {
            this.state = QuestState.Completed;
            return this.reward;
        }
        else throw new Exception("Квест уже завершён");
    }

    public int Complete(float rewardMultiplier)
    {
        if (this.state == QuestState.Taken)
        {
            this.state = QuestState.Completed;
            this.reward = ((int)(this.reward * rewardMultiplier));
            return this.reward;
        }
        else throw new Exception("Квест уже завершён");
    }
}

public enum QuestState
{
    Available, Taken, Completed
}
