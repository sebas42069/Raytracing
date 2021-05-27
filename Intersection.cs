using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace INFOGR2019Tmpl8
{
    class Intersection
    {
        public Vector3 position;
        public Primitive primitive;
        public Vector3 normal;
        public float length;
        public Intersection (Vector3 pos, Primitive prim, Vector3 norm, float len)
        {
            position = pos;
            primitive = prim;
            normal = norm;
            length = len;
        }
    }
}
