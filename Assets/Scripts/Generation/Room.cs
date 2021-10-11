using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralLayoutGeneration
{
    public class Room
    {
        private Vector2 pos;
        private float w, h;
        public Room(Vector2 pos, float w, float h)
        {
            this.pos = pos;
            this.w = w;
            this.h = h;
        }

        public void draw()
        {

            Debug.DrawLine(new Vector3(pos.x, pos.y), new Vector3(pos.x + w, pos.y), Color.red);
            Debug.DrawLine(new Vector3(pos.x, pos.y + h), new Vector3(pos.x + w, pos.y + h), Color.red);
            Debug.DrawLine(new Vector3(pos.x, pos.y), new Vector3(pos.x, pos.y + h), Color.red);
            Debug.DrawLine(new Vector3(pos.x + w, pos.y), new Vector3(pos.x + w, pos.y + h), Color.red);
        }


    }
}