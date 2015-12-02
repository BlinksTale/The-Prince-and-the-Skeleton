using UnityEngine;
using System.Collections;

public class CameraClamp : MonoBehaviour {
    public float minX = -10;
    public float maxX = 10;
    public float minY = -10;
    public float maxY = 10;
	
	void Update () {
        Vector3 pos = transform.position;
	    pos.x = Mathf.Clamp(transform.position.x, minX, maxX);
        pos.y = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
	}
}
