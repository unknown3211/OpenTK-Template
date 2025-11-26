using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace UDOpenTK
{ 
    internal class Game : GameWindow
    {
        private Mesh mesh = new Mesh();

        Vertex[] vertices =
        {
            new Vertex { position = new Vector3(0.5f, 0.5f, 0f), texCoords = new Vector2(1f, 1f) },  // top-right
            new Vertex { position = new Vector3(0.5f, -0.5f, 0f), texCoords = new Vector2(1f, 0f) }, // bottom-right
            new Vertex { position = new Vector3(-0.5f, -0.5f, 0f), texCoords = new Vector2(0f, 0f) },// bottom-left
            new Vertex { position = new Vector3(-0.5f, 0.5f, 0f), texCoords = new Vector2(0f, 1f) }  // top-left
        };

        uint[] indices =
        {
            0, 1, 3,
            1, 2, 3
        };

        int width;
        int height;

        public Game(int width, int height) : base(GameWindowSettings.Default, NativeWindowSettings.Default)
        {
            this.width = width;
            this.height = height;
            CenterWindow(new Vector2i(width, height));
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
            this.width = e.Width;
            this.height = e.Height;
        }
        protected override void OnLoad()
        {
            base.OnLoad();
            mesh.Load(vertices, indices, "default.vert", "default.frag");
            mesh.LoadTexture("brick.png");
        }
        protected override void OnUnload()
        {
            base.OnUnload();
            mesh.Shutdown();
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.ClearColor(0f, 0f, 0f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            mesh.Draw();

            Context.SwapBuffers();
            base.OnRenderFrame(args);
        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }
    }
}
