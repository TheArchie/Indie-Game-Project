using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : MissionGoal {

    public int EnemyID { get; set; }

    public KillGoal(int enemyID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.EnemyID = enemyID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Initialise()
    {
        base.Initialise();
    }

    void EnemyDied(Target enemy)
    {
        if(enemy.ID == this.EnemyID)
        {
            this.CurrentAmount += 1;
            Evaluate();
        }

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
