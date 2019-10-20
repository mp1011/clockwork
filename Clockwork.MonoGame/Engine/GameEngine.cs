using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clockwork.MonoGame.Engine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameEngine : Game
    {
        #region Setup

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public GameEngine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            //LogicManager.Reset();
            //SceneLoader.Load("start"); //todo- config
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //IOC.InitXNA(Content, spriteBatch);
            //displayEngine = IOC.Get<DisplayEngine>();

            //new XNAAudioEngine(this.Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        #endregion

        #region Logic

        public static double TimeScale = 1.0;

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            var timeInFrame = gameTime.ElapsedGameTime;
            if (TimeScale != 1.0)
                timeInFrame = TimeSpan.FromMilliseconds(timeInFrame.TotalMilliseconds * TimeScale);

           //LogicManager.Update(timeInFrame);
            //LogicManager.ProcessNewGroups();
        }

        #endregion

        #region Rendering

        private RenderTarget2D RenderTarget;

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //if (displayEngine.Painter.Camera == null)
            //    return;

            GraphicsDevice.Clear(Color.Red);
            //displayEngine.WindowPosition.Set(Window.ClientBounds);

            //if (RenderTarget == null)
            //    RenderTarget = new RenderTarget2D(GraphicsDevice, Window.ClientBounds.Width, Window.ClientBounds.Height);

            //GraphicsDevice.SetRenderTarget(RenderTarget);
            //GraphicsDevice.Clear(displayEngine.BackgroundColor);
            //spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            //displayEngine.DrawFrame();
            //spriteBatch.End();

            //var window = displayEngine.WindowPosition;

            //var cameraPosition = displayEngine.Painter.Camera.Position;
            //var scale = new Vector2((float)window.Width / (float)cameraPosition.Width, (float)window.Height / (float)cameraPosition.Height);

            //Matrix m = Matrix.CreateScale(scale.X, scale.Y, 1f);
            //this.GraphicsDevice.SetRenderTarget(null);
            //this.GraphicsDevice.Clear(Color.Red);
            //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.Default, RasterizerState.CullNone, null, m);
            //spriteBatch.Draw(RenderTarget, Vector2.Zero, Color.White);
            //spriteBatch.End();

            base.Draw(gameTime);
        }

        #endregion

    }
}
