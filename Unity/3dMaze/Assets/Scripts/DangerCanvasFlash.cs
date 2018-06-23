using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerCanvasFlash : MonoBehaviour {

    public Image img;
    Color32 color1 = new Color32(165, 50, 50, 80);
    Color32 color2 = new Color32(165, 50, 50, 180);
    Color32 flashColor;
    private float angle;
    private float alpha;
    private byte alphaByte;
    private float angularVelocity;

    public GameObject DistanceToEnemyObject;
    private InDangerZone inDangerZoneAccess;
    private float magDeltaPos;

    // Use this for initialization
    void Start () {
        inDangerZoneAccess = DistanceToEnemyObject.GetComponent<InDangerZone>();
        angle = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        magDeltaPos = Vector3.Magnitude(inDangerZoneAccess.deltaPos);
        if (magDeltaPos<23)
        {
            //angularVelocity = (15 - magDeltaPos) / 40;
            angularVelocity = 0.3f;
        }
        else
        {
            angularVelocity = 0.1f;
        }
        if (angle < 360)
        {
            angle = angle + angularVelocity;
        }
        else
        {
            angle = 1;
        }
        alpha = 80 + 60*Mathf.Sin(angle);
        alphaByte = (byte)alpha;
        //Debug.Log(angle);
        flashColor = new Color32(165, 50, 50, alphaByte);
        //Debug.Log(flashColor);
        img.color = flashColor;
    }

    
}
