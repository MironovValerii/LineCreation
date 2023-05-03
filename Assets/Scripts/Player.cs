using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private DrawLine line;
    [SerializeField] private DrawLine line2;
    [SerializeField] private LineRenderer player;
    [SerializeField] private LineRenderer player2;
    public GameObject panel;
    public GameObject panelNextLevel;


    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("collision", true);
        line.isFinish = false;
    }

    public void Update()
    {
        if (line.isFinish && line2.isFinish)
        {
            animator.SetTrigger("isFinish");
        }
        if ((line.i == player.positionCount) && (line.i != 0) && (line2.i == player2.positionCount))
        {
            animator.SetTrigger("end");
        }
    }
    public void SetPanel()
    {
        panel.SetActive(true);
    }

    public void SetNextLevelPanel()
    {
        panelNextLevel.SetActive(true);
    }
}
