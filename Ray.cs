using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace INFOGR2019Tmpl8
{
    class Ray
    {
        public Vector3 position;
        public Vector3 direction;
        public float length;
        public Ray(Vector3 pos, Vector3 dir, float len)
        {
            position = pos;
            direction = dir;
            length = len;
        }
    }
}
