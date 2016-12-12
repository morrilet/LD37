using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreTextController : MonoBehaviour 
{
	public delegate void MilestoneAction();
	public static event MilestoneAction OnMilestoneReached;

	public struct ScoreMilestone
	{
		bool isUsed;
		int milestoneScore;

		public ScoreMilestone (int _milestoneScore)
		{
			isUsed = false;
			milestoneScore = _milestoneScore;
		}

		public int GetMilestoneScore () { return milestoneScore; }
		public void SetUsed (bool value) { isUsed = value; }
		public bool GetUsed () { return isUsed; }
	}

	[SerializeField]
	protected List<ScoreMilestone> milestones;

	private const int DEFAULT_MILESTONE = 10000; //This is the milestone to use once all others have been used.
	private int defaultMilestoneCount; //How many times the default milestone has been passed.

	void Start()
	{
		defaultMilestoneCount = 0;

		//Set Milestones...
		milestones = new List<ScoreMilestone> ();
		milestones.Add (new ScoreMilestone (1000));
		milestones.Add (new ScoreMilestone (2500));
		milestones.Add (new ScoreMilestone (5000));
	}

	void Update()
	{
		CheckMilestones ();
	}

	//Checks whether or not a milestone has been achieved.
	void CheckMilestones()
	{
		if (milestones.Count != 0) 
		{
			for (int i = 0; i < milestones.Count; i++) 
			{
				if (GameManager.GetScore () >= milestones [i].GetMilestoneScore ()) 
				{
					if (!milestones [i].GetUsed ()) 
					{
						milestones [i].SetUsed (true);
						milestones.RemoveAt (i);

						if (OnMilestoneReached != null) {
							OnMilestoneReached ();
						}
						break;
					}
				}
			}
		} 
		else 
		{
			if ((int)GameManager.GetScore () / DEFAULT_MILESTONE > defaultMilestoneCount) 
			{
				defaultMilestoneCount++;
				OnMilestoneReached ();
			}
		}
	}
}
