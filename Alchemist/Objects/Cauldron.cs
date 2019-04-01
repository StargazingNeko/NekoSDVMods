using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;

using StardewValley;
using StardewValley.Tools;




namespace Alchemist.Objects
{

    public class Cauldron : Object
    {
        public Cauldron() : base()
        {
            this.Name = "Cauldron";
            //this.description = "A pot used for alchemical brewery.";
            type.Value = "interactive";
            this.CanBeSetDown = true;
            this.Category = BigCraftableCategory;

        }
        
         protected override string loadDisplayName()
         {
             return Name;
         }

        public override bool canBeGivenAsGift()
        {
            return false;
        }

        public override bool canBeShipped()
        {
            return false;
        }

        public override bool canBeTrashed()
        {
            return true;
        }

        public Dictionary<string, string> GetAdditionalSaveData()
         {
             Dictionary<string, string> savedata = new Dictionary<string, string>
             {
                 { "name", Name }
             };
             return savedata;
         }

         public dynamic GetReplacement()
         {
             FishingRod replacement = new FishingRod();
             return replacement;
         }

         public void Rebuild(Dictionary<string, string> additionalSaveData, object replacement)
         {
             this.Name = additionalSaveData["name"];
         }
    }
}
