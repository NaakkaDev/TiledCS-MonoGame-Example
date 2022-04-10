using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TiledCS;

namespace TiledCS_MonoGame_Example
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private TiledMap _map;
        private TiledTileset _tileset;
        private Texture2D _tilesetTexture;

        private int _tileWidth;
        private int _tileHeight;
        private int _tilesetTilesWide;
        private int _tilesetTilesHeight;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Set the "Copy to Output Directory" property of these two files to `Copy if newer`
            // by clicking them in the solution explorer.
            _map = new TiledMap(Content.RootDirectory + "\\exampleMap.tmx");
            _tileset = new TiledTileset(Content.RootDirectory + "\\exampleTileset.tsx");

            // Not the best way to do this but it works. It looks for "exampleTileset.xnb" file
            // which is the result of building the image file with "Content.mgcb".
            _tilesetTexture = Content.Load<Texture2D>("exampleTileset");

            _tileWidth = _tileset.TileWidth;
            _tileHeight = _tileset.TileHeight;

            // Amount of tiles on each row (left right)
            _tilesetTilesWide = _tileset.Columns;
            // Amount of tiels on each column (up down)
            _tilesetTilesHeight = _tileset.TileCount / _tileset.Columns;

            // Print "Sun" to the debug console. This is an object in "Object Layer 1".
            System.Diagnostics.Debug.WriteLine(_map.Layers[1].objects[0].name);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            for (var i = 0; i < _map.Layers[0].data.Length; i++)
            {
                int gid = _map.Layers[0].data[i];

                // Empty tile, do nothing
                if (gid == 0)
                {

                }
                else
                {
                    // Tileset tile ID
                    // Looking at the exampleTileset.png
                    // 0 = Blue
                    // 1 = Green
                    // 2 = Dark Yellow
                    // 3 = Magenta
                    int tileFrame = gid - 1;
                 
                    int column = tileFrame % _tilesetTilesWide;
                    int row = (int)Math.Floor((double)tileFrame / (double)_tilesetTilesWide);

                    float x = (i % _map.Width) * _map.TileWidth;
                    float y = (float)Math.Floor(i / (double)_map.Width) * _map.TileHeight;

                    Rectangle tilesetRec = new Rectangle(_tileWidth * column, _tileHeight * row, _tileWidth, _tileHeight);

                    _spriteBatch.Draw(_tilesetTexture, new Rectangle((int)x, (int)y, _tileWidth, _tileHeight), tilesetRec, Color.White);
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
