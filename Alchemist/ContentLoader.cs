using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewValley;

namespace Alchemist
{
    public class ContentLoader : IAssetEditor
    {
        private readonly Texture2D _spritesheet_x;
        private readonly Texture2D _texture_z;

        public ContentLoader(Texture2D spritesheet_x, Texture2D texture_z)
        {
            _spritesheet_x = spritesheet_x;
            _texture_z = texture_z;
        }

        public bool CanEdit<T>(IAssetInfo asset)
        {
            return asset.AssetNameEquals("assets\\sprites\\objects");
        }

        public void Edit<T>(IAssetData asset)
        {
            if (asset.AssetNameEquals("assets\\sprites\\objects"))
            {
                Texture2D texture_x = asset.AsImage().Data;
                int originalWidth = _spritesheet_x.Width;
                int originalHeight = _spritesheet_x.Height;
                Texture2D spriteSheet = _spritesheet_x;
                Texture2D newSpriteSheet = new Texture2D(Game1.game1.GraphicsDevice, originalWidth, originalHeight);
            }
        }
    }
}
