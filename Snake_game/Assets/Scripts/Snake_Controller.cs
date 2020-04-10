using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Snake_Controller : MonoBehaviour
{
    public List<Transform> Tails;
    [Range(1,3)]
    public float BonesDistance;
    public GameObject BonePrefab;
    [Range(0, 4)]
    public float Speed;
    private Transform _transform;

    public static int countFood = 0;
    public Text countFoodUI;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveSnake(_transform.position + _transform.forward * Speed);

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _transform.Rotate(0.0f, 90.0f, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _transform.Rotate(0.0f, 270.0f, 0.0f);
        }
    }

    private void MoveSnake(Vector3 newPosition)
    {
        float sqrDistance = BonesDistance * BonesDistance;
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

        _transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            countFoodUI.GetComponent<Text>().text = "Count of food: " + ++countFood;
            Destroy(collision.gameObject);

            var bone = Instantiate(BonePrefab);
            Tails.Add(bone.transform);
        }

        if (collision.gameObject.tag == "Danger")
        {
            SceneManager.LoadScene(2);
        }
    }
}
