using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFOGR2019Tmpl8
{
    class Camera
    {
        public Vector3 position;
        public Vector3 topLeft;
        public Vector3 topRight;
        public Vector3 bottomLeft;
        public Vector3 bottomRight;


        public Camera(Vector3 pos, Vector3 tLeft, Vector3 tRight, Vector3 bLeft, Vector3 bRight)
        {
            position = pos;
            topLeft = tLeft;
            topRight = tRight;
            bottomLeft = bLeft;
            bottomRight = bRight;
        }

        public Vector3 RectangleStuff(float x, float y)
        {
            return bottomLeft * x * y + bottomRight * (1 - x) * y + topLeft * x * (1 - y) + topRight * (1 - x) * (1 - y);
        }
    }
}
