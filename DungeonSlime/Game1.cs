using System;
using System.Security.Principal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;

namespace DungeonSlime;

public class Game1 : Core
{
    // The MonoGame logo texture
    private Texture2D _logo;

    public Game1() : base("Dungeon Slime", 1280, 720, false)
    {
        
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
        _logo = Content.Load<Texture2D>("images/logo");

        // base.LoadContent();
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

        // The bounds of the icon within the texture
        Rectangle iconSourceRect = new Rectangle(0, 0, 128, 128);

        // The bounds of the word mark within the texture
        Rectangle wordmarkSourceRect = new Rectangle(150, 34, 458, 58);

        Vector2 screenCenter = new Vector2(Window.ClientBounds.Width, 
                                            Window.ClientBounds.Height) * 0.5f;

        Vector2 wordmarkOrigin = new Vector2(wordmarkSourceRect.Width,
                                        wordmarkSourceRect.Height) * 0.5f;

        Vector2 iconOrigin = new Vector2(iconSourceRect.Width,
                                        iconSourceRect.Height) * 0.5f;
        
        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin();

        // Draw the wordmark
        SpriteBatch.Draw(
            _logo,                  // texture
            // position: screen center offset by icon drawing
            screenCenter + (Vector2.UnitX * iconOrigin),
            wordmarkSourceRect,     // source rectangle
            Color.Green * 0.5f,     // color mask * opacity
            MathHelper.ToRadians(0),// rotation
            wordmarkOrigin,
            new Vector2(1.0f, 1.0f),// scale
            SpriteEffects.FlipHorizontally |
            SpriteEffects.FlipVertically, // effects
            0.0f                    // layer depth
        );

        // Draw the logo
        SpriteBatch.Draw(
            _logo,
            // position: left of wordmark and drawn accounting for own icon offset
            // NOTE: this is bad and confusing. I just wanted to make sure I understand
            // what's happening with drawing, vectors, and objects
            screenCenter - (Vector2.UnitX * wordmarkOrigin) 
                         - (Vector2.UnitX * iconOrigin * 0.5f),
            iconSourceRect,
            Color.White,
            MathHelper.ToRadians(90),
            iconOrigin,
            1.0f,
            SpriteEffects.None,
            0.0f
        );

        // Always end the sprite batch when finished.
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
