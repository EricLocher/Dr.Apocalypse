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

            this.pos.x = Mathf.Round(this.pos.x * 10) / 10;
            this.pos.y = Mathf.Round(this.pos.y * 10) / 10;
        }

        public void draw()
        {
            this.pos.x = Mathf.Round(this.pos.x * 10) / 10;
            this.pos.y = Mathf.Round(this.pos.y * 10) / 10;
            Debug.Log(this.pos.x + " : " + this.pos.y);

            Debug.DrawLine(new Vector3(pos.x, pos.y), new Vector3(pos.x + w, pos.y), Color.red);
            Debug.DrawLine(new Vector3(pos.x, pos.y + h), new Vector3(pos.x + w, pos.y + h), Color.red);
            Debug.DrawLine(new Vector3(pos.x, pos.y), new Vector3(pos.x, pos.y + h), Color.red);
            Debug.DrawLine(new Vector3(pos.x + w, pos.y), new Vector3(pos.x + w, pos.y + h), Color.red);
        }

        public void Collision(List<Room> rooms)
        {
            foreach (Room room in rooms)
            {
                if (this == room) { break; }
                if
                (
                  ((this.pos.x + this.w) > room.pos.x && this.pos.x < (room.pos.x + room.w))
                  &&
                  ((this.pos.y + this.h) > room.pos.y && this.pos.y < (room.pos.y + room.h))
                )
                {
                    Vector2 _rect1Center = new Vector2(this.pos.x + (this.w / 2), this.pos.y + (this.h / 2));
                    Vector2 _rect2Center = new Vector2(room.pos.x + (room.w / 2), room.pos.y + (room.h / 2));

                    float _xDiff = Mathf.Abs(_rect1Center.x - _rect2Center.x);
                    float _yDiff = Mathf.Abs(_rect1Center.y - _rect2Center.y);

                    if (_xDiff > _yDiff)
                    {
                        if (_rect1Center.x < _rect2Center.x)
                        {
                            this.pos.x -= (float)0.1;
                            room.pos.x += (float)0.1;
                        }
                        else
                        {
                            this.pos.x += (float)0.1;
                            room.pos.x -= (float)0.1;
                        }
                    }
                    else
                    {
                        if (_rect1Center.y < _rect2Center.y)
                        {
                            this.pos.y -= (float)0.1;
                            room.pos.y += (float)0.1;
                        }
                        else
                        {
                            this.pos.y += (float)0.1;
                            room.pos.y -= (float)0.1;
                        }
                    }
                }
            }
        }
    }
}