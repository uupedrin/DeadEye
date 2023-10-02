using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	private bool isBad;
	
	public bool IsBad
	{
		get
		{
			return isBad;
		}
		set
		{
			isBad = value;
			
			if(isBad)
			{
				//Change to bad material
			}
			else
			{
				//Change to original material
			}
		}
	}
	
	private void OnDestroy()
	{
		if(isBad)
		{
			// Reduce points
		}
		else
		{
			// Increase points
		}
	}
}
