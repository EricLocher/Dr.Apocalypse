using UnityEngine;
using ProceduralLayoutGeneration;
using System.Collections.Generic;

public class ProceduralLayout : MonoBehaviour
{
    [SerializeField]
    private int amountOfRooms;
    private List<Room> rooms = new List<Room>();

    //TEMP
    float _SCircleRadius = 3;

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

    }



}