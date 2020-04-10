using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FoodGeneration : MonoBehaviour
{
    public float XSize = 18f;

    public float ZSize = 18f;

    public GameObject foodPrefab;

    public Vector3 curPos;

    public GameObject curFood;
    void AddNewFood()
    {
        RandomPos();
        curFood = GameObject.Instantiate(foodPrefab, curPos, Quaternion.identity);
    }

    void RandomPos()
    {
        curPos = new Vector3(Random.Range(XSize*-1,XSize),0.6f, Random.Range(ZSize * -1, ZSize));
    }

    // Update is called once per frame
    void Update()
    {
        if (!curFood)
        {
            AddNewFood();
        }
        else
        {
            return;
        }
    }
}
