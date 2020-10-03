using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    Transform playerTrans;
    float xLerp;
    float yLerp;

    [SerializeField]
    float moveSpeed = 5f;

    private void Awake()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = Vector2.Lerp(transform.position, playerTrans.position, moveSpeed);
        transform.position = new Vector3(newPos.x, newPos.y +1, -10);
    }
}
