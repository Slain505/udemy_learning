using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform mainPoint;
    public Transform farBG, midBG;

    // private float lastXpos;
    private Vector2 lastPos;
    public float minHeight;
    public float maxHeight;

    // Start is called before the first frame update
    void Start()
    {
       lastPos = transform.position;
       // lastPos.x = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // lastXpos = transform.position.x;
        // transform.position = new Vector3(mainPoint.position.x, mainPoint.position.y, transform.position.z);
        lastPos = transform.position;
        transform.position = new Vector3(mainPoint.position.x, Mathf.Clamp(mainPoint.position.y, minHeight, maxHeight), transform.position.z);

        // float amountToMoveX = transform.position.x - lastPos.x;

        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        farBG.position = farBG.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        midBG.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;
    
    
    }
}
