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
        public enum Material { diffuse, glossy };
        public Material material;
        public Vector3 position;
        public Vector3 color;
        public float radius;
        float alpha = 5; 
        public Primitive()
        {
           
        }

        public virtual Intersection IntersectWith(Ray ray)
        {
            return null;
        }

        public float ReflectedLight(Primitive p, Light l, Intersection i, Camera c)
        {
            float max = 0f;
            if(p.material == Material.diffuse)
            {
                float angle = Vector3.Dot(i.position - p.position, l.position - i.position);
                max = Math.Max(0, angle);
            }

            else if (p.material == Material.glossy)
            {
                float reflection = Vector3.Dot(c.position - i.position, l.position - i.position - 2 * (Vector3.Dot(l.position - i.position, i.position - p.position) * (i.position - p.position)));
                max = (float)Math.Pow((double)Math.Max(0, reflection), (double)alpha);
            }

            return max;
        }
    }
}
