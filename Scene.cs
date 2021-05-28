using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace INFOGR2019Tmpl8
{
    class Scene
    {
        public List<Primitive> primitives = new List<Primitive>();
        List<Sphere> spheres = new List<Sphere>();
        Plane plane = new Plane(Vector3.Zero);
        public Light light1;

        public void Init()
        {
            spheres.Add(new Sphere(new Vector3(-3, 0, 5), 2f, new Vector3(1,0,0), Primitive.Material.diffuse));
            spheres.Add(new Sphere(new Vector3(0, 0, 0), 2f, new Vector3(0,1,0), Primitive.Material.diffuse));
            spheres.Add(new Sphere(new Vector3(3, 0, 5), 2f, new Vector3(0,0,1), Primitive.Material.glossy));
            foreach (Sphere s in spheres)
            {
                primitives.Add(s);
            }
            primitives.Add(plane);
            light1 = new Light(new Vector3(10, 10, -3), 0.5f);
        }

        public Intersection Intersect(Ray ray)
        {
            Intersection res = null;
            foreach (Primitive p in primitives)
            {
                Intersection i = p.IntersectWith(ray);
                if (i != null)
                {
                    res = i;
                }
            }
            return res;
        }

        public void DebugDraw(Surface screen)
        {
            foreach (Sphere s in spheres)
            {
                for (int i = 0; i < 100; i++)
                {
                    screen.Line(MyApplication.TX(s.position.X + s.radius * Math.Cos(i * Math.PI / 50), screen), MyApplication.TY(s.position.Z + s.radius * Math.Sin(i * Math.PI / 50), screen),
                        MyApplication.TX(s.position.X + s.radius * Math.Cos((i + 1) * Math.PI / 50), screen), MyApplication.TY(s.position.Z + s.radius * Math.Sin((i + 1) * Math.PI / 50), screen), 255);
                }
            }


        }
    }
}
