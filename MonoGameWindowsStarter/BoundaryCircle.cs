using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoGameWindowsStarter
{
    public struct BoundaryCircle
    {
        public float X;

        public float Y;

        public float Radius;

        public Vector2 Center
        {
            get => new Vector2(X, Y);
            set => new Vector2(X, Y)
            {
                X = value.X,
                Y = value.Y
            };
        }


    }
}
