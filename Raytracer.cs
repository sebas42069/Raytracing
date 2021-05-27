using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace INFOGR2019Tmpl8
{
    class Raytracer
    {
        Vector3 origin;
        Vector3 direction;
        Camera camera;
        Surface debugScreen;
        Surface rtScreen;

        Scene rtScene = new Scene();

        public Raytracer(Vector3 o, Vector3 dir, Camera c, Surface dScreen, Surface rScreen)
        {
            origin = o;
            direction = dir;
            camera = c;
            debugScreen = dScreen;
            rtScreen = rScreen;
            rtScene.Init();
        }


        public void Render()
        {
            for(int x = 0; x < rtScreen.width; x++)
            {
                for(int y = 0; y < rtScreen.height; y++)
                {
                    Vector3 pixel = camera.RectangleStuff((float)x / rtScreen.width, (float)y / rtScreen.height);
                    Vector3 rayDir = pixel - camera.position;
                    rayDir.NormalizeFast();

                    Ray ray = new Ray(camera.position, rayDir, 10000);


                    Intersection inter = rtScene.Intersect(ray);
                    if (y == rtScreen.height / 2 && x % 20 == 0)
                    {
                        debugScreen.Line(MyApplication.TX(camera.position.X, debugScreen), MyApplication.TY(camera.position.Z, debugScreen),
                            MyApplication.TX(ray.position.X + ray.direction.X * ray.length, debugScreen), MyApplication.TY(ray.position.Z + ray.direction.Z * ray.length, debugScreen), MixColor(new Vector3(1,1,0)));
                    }

                    if (inter != null)
                    {
                        rtScreen.Plot(x, y, MixColor(inter.primitive.color));
                    }
                    else
                    {
                        rtScreen.Plot(x, y, 0);
                    }
                }
            }

            rtScene.DebugDraw(debugScreen);
        }


        int MixColor(Vector3 Color)
        {
            int red = Math.Max(Math.Min((int)(Color.X * 255), 255), 0);
            int green = Math.Max(Math.Min((int)(Color.Y * 255), 255), 0);
            int blue = Math.Max(Math.Min((int)(Color.Z * 255), 255), 0);
            return (red << 16) + (green << 8) + blue;
        }
    }
}
