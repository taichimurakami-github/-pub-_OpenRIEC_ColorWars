using UnityEngine;

public interface IPaint
{
	void PaintOnRay(Vector3 rayOrigin, Vector3 rayDirection);

	void PaintOnTarget(PaintTarget Target, Vector3 point, Vector3 normal);
	void ClearAll();
}
