using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;

using StardewValley;
using StardewModdingAPI;

namespace ContentLoader
{
    public class ContentLoader
    {

        public class CraftablesLoader : IAssetEditor
        {

            private readonly Texture2D _craftablesSpriteSheet;
            private readonly Texture2D _menuTilesSpriteSheet;

            public CraftablesLoader(Texture2D craftablesSpriteSheet, Texture2D menuTilesSpriteSheet)
            {
                _craftablesSpriteSheet = craftablesSpriteSheet;
                _menuTilesSpriteSheet = menuTilesSpriteSheet;
            }

            public bool CanEdit<T>(IAssetInfo asset)
            {
                return asset.AssetNameEquals("TileSheets\\Craftables");
            }

            public void Edit<T>(IAssetData asset)
            {
                
            }
        }

        public class WeaponsLoader : IAssetEditor
        {
            private readonly Texture2D _weaponsSpriteSheet;
            private readonly Texture2D _menuTilesSpriteSheet;

            public WeaponsLoader(Texture2D weaponsSpriteSheet, Texture2D menuTilesSpriteSheet)
            {
                _weaponsSpriteSheet = weaponsSpriteSheet;
                _menuTilesSpriteSheet = menuTilesSpriteSheet;
            }

            public bool CanEdit<T>(IAssetInfo asset)
            {
                return asset.AssetNameEquals("TileSheets\\weapons") || asset.AssetNameEquals("Maps\\MenuTiles");
            }

            public void Edit<T>(IAssetData asset)
            {
                
            }
        }

        public class ToolsLoader : IAssetEditor
        {
            private readonly Texture2D _toolsSpriteSheet;
            private readonly Texture2D _menuTilesSpriteSheet;

            public ToolsLoader(Texture2D toolsSpriteSheet, Texture2D menuTilesSpriteSheet)
            {
                _toolsSpriteSheet = toolsSpriteSheet;
                _menuTilesSpriteSheet = menuTilesSpriteSheet;
            }

            public bool CanEdit<T>(IAssetInfo asset)
            {
                return asset.AssetNameEquals("TileSheets\\tools") || asset.AssetNameEquals("Maps\\MenuTiles");
            }

            public void Edit<T>(IAssetData asset)
            {
                
            }
        }

        public class ObjectLoader : IAssetEditor
        {
            public bool CanEdit<T>(IAssetInfo asset)
            {
                return asset.AssetNameEquals("Maps\\springobjects") || asset.AssetNameEquals("Data\\boots") || asset.AssetNameEquals("Data\\ObjectInformation");
            }

            public void Edit<T>(IAssetData asset)
            {
                
            }
        }

        public class RecipeLoader : IAssetEditor
        {
            public bool CanEdit<T>(IAssetInfo asset)
            {
                return asset.AssetNameEquals("Data\\CookingRecipes");
            }

            public void Edit<T>(IAssetData asset)
            {
                
            }
        }

        public class FurnitureLoader : IAssetEditor
        {
            public bool CanEdit<T>(IAssetInfo asset)
            {
                return asset.AssetNameEquals("TileSheets\\Furniture");
            }

            public void Edit<T>(IAssetData asset)
            {

            }
        }
    }
}
