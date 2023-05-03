using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject finish;
    [SerializeField] private DrawLine player2;
    public bool isFinish = false;
    public int i = 0;
    private bool isMove = true;

    private void Start()
    {
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        line.positionCount = 0;
        isMove = true;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && (isFinish == false))
        {
            Vector2 currentPoint = GetWorldCoordinate(Input.mousePosition);
            line.positionCount++;
            line.SetPosition(line.positionCount-1, currentPoint);
            if ((line.GetPosition(0).x < (start.transform.position.x-0.5f)) || (line.GetPosition(0).x > (start.transform.position.x + 0.5f)) || (line.GetPosition(0).y < (start.transform.position.y - 0.5f)) || (line.GetPosition(0).y > (start.transform.position.y + 0.5f)))
            {
                line.positionCount = 0;
            }
            if ((line.GetPosition(line.positionCount - 1).x > (finish.transform.position.x - 0.45f)) && (line.GetPosition(line.positionCount - 1).x < (finish.transform.position.x + 0.45f)) && (line.GetPosition(line.positionCount - 1).y > (finish.transform.position.y - 0.45f)) && (line.GetPosition(line.positionCount - 1).y < (finish.transform.position.y + 0.45f)))
            {
                isFinish = true;
                Debug.Log(isFinish);
            }
        }
        if (isFinish && player2.isFinish && isMove)
        {
            if (i < line.positionCount)
            {
                isMove = false;
                if (line.positionCount < player2.line.positionCount)
                    Invoke("MoveStart", 0.035f);
                else
                {
                    Invoke("MoveStart", 0.035f * ((float)player2.line.positionCount / (float)line.positionCount));
                    //Debug.Log((float)player2.line.positionCount / (float)line.positionCount);
                }
            }
            
        }
        if (!(Input.GetMouseButton(0)) && (isFinish == false) && (i==0))
        {
            line.positionCount = 0;
        }
    }
    private Vector3 GetWorldCoordinate(Vector3 mousePosition)
    {
        Vector3 mousePoint = new Vector3(mousePosition.x, mousePosition.y, 1);  
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void MoveStart()
    {
    if ((isFinish != false))
        {
            start.transform.position = Vector3.Lerp(start.transform.position, line.GetPosition(i), 1f);
            i++;
            //Debug.Log(i);
            isMove = true;
        }
    }
}
