using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace UDOpenTK
{ 
    internal class Game : GameWindow
    {
        float[] vertices =
        {
            0f, 0.5f, 0f, // top
           -0.5f, -0.5f, 0f, // bottom left
           0.5f, -0.5f, 0f // bottom right
        };

        int width;
        int height;

        private Mesh mesh = new Mesh();
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
            mesh.Load(vertices, "default.vert", "default.frag");
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
