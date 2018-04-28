using System.Collections;
using System;
using UnityEngine;

public class DistanceCompare : IComparer {
    private Transform CompareTransform;

    public DistanceCompare(Transform compTransform)
    {
        CompareTransform = compTransform;
	}
	
	public int Compare (object x , object y) {
        Collider xCollider = x as Collider;
        Collider yCollider = y as Collider;
        Vector3 offset = xCollider.transform.position - CompareTransform.position;
        float xDistance = offset.sqrMagnitude;
        offset = yCollider.transform.position - CompareTransform.position;
        float yDistance = offset.sqrMagnitude;
        return xDistance.CompareTo(yDistance);

	}
}
