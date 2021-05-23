using OpenTK.Graphics.OpenGL;
using OpenTK;
using System;
using System.IO;

namespace Template
{
	class MyApplication
	{
		// member variables
		public Surface screen, debugScreen, rtScreen;

		int centerx;
		int centery;

		// initialize
		public void Init()
		{
			debugScreen = new Surface(512, 512);
			debugScreen.Clear(0x0000ff);
			rtScreen = new Surface(512, 512);
			rtScreen.Clear(0xffff00);
		}
		// tick: renders one frame
		public void Tick()
		{
			debugScreen.CopyTo(screen, 0, 0);
			rtScreen.CopyTo(screen, 512, 0);
		}

        public int TX(float coordx)
        {
			return (int)((coordx + centerx + 1) * screen.width / 2);
        }

        public int TY(float coordy)
        {
			return (int)(screen.height - (coordy + centery) * screen.height / 2 - screen.height / 2);
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