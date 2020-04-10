using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentLogic : MonoBehaviour
{
    public List<Transform> Tails;
    [Range(1, 3)]
    public float OponBonesDistance;
    public GameObject snake;
    [Range(0, 4)]
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveSnake();
    }

    private void MoveSnake()
    {
        float sqrDistance = OponBonesDistance * OponBonesDistance;
        Vector3 previousPosition = _transform.position;

        foreach (var bone in Tails)
        {
            if ((bone.position - previousPosition).sqrMagnitude > sqrDistance)
            {
                var temp = bone.position;
                bone.position = previousPosition;
                previousPosition = temp;
            }
            else
            {
                break;
            }
        }

        transform.position = Vector3.MoveTowards(
            transform.position, //current position
            snake.transform.position, //target position
            Time.deltaTime //step
        );
    }
}
