using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFOGR2019Tmpl8
{
    class Sphere : Primitive
    {
        public float radius;

        public Sphere (Vector3 pos, float rad, Vector3 col)
        {
            position = pos;
            radius = rad;
            color = col;
        }

        public override Intersection IntersectWith(Ray ray)
        {
            Vector3 c = position - ray.position;
            float t = Vector3.Dot(c, ray.direction);
            Vector3 q = c - t * ray.direction;
            float p = q.Length;
            if (p > radius) return null;
            t -= (float)Math.Sqrt(radius * radius - p * p);
            if ((t < ray.length) && (t > 0))
            {
                ray.length = t;
                Vector3 pos = ray.position + ray.direction * ray.length;
                Vector3 norm = pos - position;
                norm.NormalizeFast();
                return new Intersection(pos, this, norm, t);
            }
            return null;
        }
    }
}
