using OpenTK.Graphics.OpenGL;
using OpenTK;
using System;
using System.IO;
using INFOGR2019Tmpl8;

namespace Template
{
	class MyApplication
	{
		// member variables
		public Surface screen, debugScreen, rtScreen;

		int centerx;
		int centery;

		Vector3 originCam = new Vector3(0,0,-10);
		Vector3 dirCam = new Vector3(0,0,1);

		Raytracer tracer;
		// initialize
		public void Init()
		{
			debugScreen = new Surface(512, 512);
			debugScreen.Clear(0x000000);
			rtScreen = new Surface(512, 512);
			rtScreen.Clear(0xffff00);

			Camera Cam = new Camera(originCam, new Vector3(-1, 1, -8), new Vector3(1, 1, -8), new Vector3(-1, -1, -8), new Vector3(1, -1, -8));
			tracer = new Raytracer(originCam, dirCam, Cam, debugScreen, rtScreen);


		}
		// tick: renders one frame
		public void Tick()
		{
			tracer.Render();

			debugScreen.CopyTo(screen, 0, 0);
			rtScreen.CopyTo(screen, 512, 0);
		}

		public static int TX(double coordx, Surface screen)
		{
			return screen.width - (int)((coordx + 10) * screen.width / 20);
		}

		public static int TY(double coordy, Surface screen)
		{
			return screen.height - (int)((coordy + 10) * screen.height / 20);
		}

		public float DX(int coordx)
        {
			return (float)coordx / 178 - 1;
        }

		public float DY(int coordy)
		{
			return (float)coordy / 178 - 1;
		}



		public void RenderGL()
        {
			
        }
	}
}