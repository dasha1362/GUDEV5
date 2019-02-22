using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilFunctions
{

	public static GameObject FindClosestObject(Vector3 origin, GameObject[] objects)
	{
		GameObject closestObject = objects[0];
		foreach (GameObject obj in objects)
		{
			if(Vector3.Distance(origin, obj.transform.position) <= Vector3.Distance(origin, closestObject.transform.position))
			{
				closestObject = obj;
			}
		}
		return closestObject;
	}

}