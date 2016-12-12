using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreTextController : MonoBehaviour 
{
	public delegate void MilestoneAction();
	public static event MilestoneAction OnMilestoneReached;

	[SerializeField]
	protected List<int> milestones;
	private const int DEFAULT_MILESTONE = 10000; //This is the milestone to use once all others have been used.
	private int defaultMilestoneCount; //How many times the default milestone has been passed.

	void Start()
	{
		defaultMilestoneCount = 0;
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
				if (GameManager.GetScore () >= milestones [i]) 
				{
					milestones.RemoveAt (i);

					if (OnMilestoneReached != null)
					{
						OnMilestoneReached ();
					}
					break;
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
