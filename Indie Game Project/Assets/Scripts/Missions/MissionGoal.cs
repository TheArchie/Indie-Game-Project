using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MissionGoal {

    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }
    public int RequiredAmount { get; set; }

    public virtual void Initialise()
    {

    }

    public void Evaluate()
    {
        if(CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        Completed = true;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
