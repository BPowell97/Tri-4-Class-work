using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenTrial : MonoBehaviour
{

    public GameObject player;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            MoveObject();
    }

    void MoveObject()
    {
        Vector3 newPos = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        player.transform.DOJump(newPos, 2f, 2, 1f); // 2 in the middle equals number of jumps
        //player.transform.DOMove(newPos, 2f); // Player movement use
        player.transform.DORotate(Vector3.up * 90, 2f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutExpo);
        player.GetComponent<Renderer>().material.DOColor(newColor, 1f);
    }
}
