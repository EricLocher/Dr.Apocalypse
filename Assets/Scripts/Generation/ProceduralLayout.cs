using UnityEngine;
using ProceduralLayoutGeneration;
using System.Collections.Generic;

public class ProceduralLayout : MonoBehaviour
{
    [SerializeField]
    private int amountOfRooms;
    private List<Room> rooms = new List<Room>();

    //TEMP
    [SerializeField]
    private float _SCircleRadius = 3;

    private void Awake()
    {

    }

    private void Start()
    {
        GenerateRooms();
    }

    private void Update()
    {
        if(rooms.Count > 0)
        foreach (Room room in rooms)
        {
            room.Collision(rooms);
            room.draw();
        }

    }

    //TEMP FUNCTION FOR TESTING
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _SCircleRadius);
    }

    private void GenerateRooms()
    {

        for (int i = 0; i < amountOfRooms; i++)
        {
            while (true)
            {

                float _roomX = Random.Range(transform.position.x - _SCircleRadius, transform.position.x + _SCircleRadius);
                float _roomY = Random.Range(transform.position.y - _SCircleRadius, transform.position.y + _SCircleRadius);

                float _roomW = generateGaussian((float)0.5, 2, 100);
                float _roomH = generateGaussian((float)0.5, 2, 100);

                if (Mathf.Pow((_roomX + (_roomW / 2)) - transform.position.x, 2) + Mathf.Pow((_roomY + (_roomH / 2)) - transform.position.y, 2) < Mathf.Pow(_SCircleRadius, 2))
                {
                    rooms.Add(new Room(new Vector2(_roomX, _roomY), _roomW, _roomH));
                    break;
                }

            }

        }

    }



    private float generateGaussian(float min, float max, float std)
    {
        while (true)
        {
            float mean = (min + max) / 2;
            float _2PI = Mathf.PI * 2;
            float u1 = Random.value;
            float u2 = Random.value;

            float z0 = Mathf.Sqrt((float)(-2.0 * Mathf.Log(u1))) * Mathf.Cos(_2PI * u2);
            float z1 = Mathf.Sqrt((float)(-2.0 * Mathf.Log(u1))) * Mathf.Sin(_2PI * u2);

            float retVal = z0 * std + mean;
            if (retVal > min && retVal < max)
            {
                return retVal;
            }
        }
    }

}