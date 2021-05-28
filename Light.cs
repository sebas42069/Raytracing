using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFOGR2019Tmpl8
{
    class Light
    {
        public Vector3 position;
        public float intensity;
        public Light(Vector3 pos, float inte)
        {
            position = pos;
            intensity = inte;
        }
    }
}
