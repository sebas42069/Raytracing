using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFOGR2019Tmpl8
{
    class Primitive
    {
        public Vector3 position;
        public Vector3 color;
        public Primitive()
        {
           
        }

        public virtual Intersection IntersectWith(Ray ray)
        {
            return null;
        }
    }
}
