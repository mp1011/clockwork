using Clockwork.Engine.Services;
using Clockwork.Engine.Services.Graphics;
using Clockwork.Engine.Services.ObjectLoaders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Clockwork.MonoGame.Engine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameEngine : Game
    {
        private RenderService _renderService;
        private SceneManager _sceneManager;
        private ContentManagerProvider _contentManagerProvider;

        #region Setup

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public GameEngine(RenderService renderService, SceneManager sceneManager, 
            ContentManagerProvider contentManagerProvider )
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = FindContentFolder().FullName;

            _renderService = renderService;
            _sceneManager = sceneManager;
            _contentManagerProvider = contentManagerProvider;
        }

        private DirectoryInfo FindContentFolder()
        {
            var directory = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory;

            while (true)
            {
                var contentFolder = new DirectoryInfo(directory.FullName + @"\Clockwork.Engine\Content");
                if (contentFolder.Exists)
                    return contentFolder;
                else
                    directory = directory.Parent;
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _contentManagerProvider.ContentManager = Content;
            _sceneManager.LoadInitialScene();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
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

            var scene = _sceneManager.GetCurrentScene();
            _renderService.RenderScene(null, scene);


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
