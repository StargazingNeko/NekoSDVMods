using PyTK.CustomElementHandler;
using StardewValley;
using StardewValley.Tools;
using System.Collections.Generic;


namespace Alchemist.Objects
{

    public abstract class Cauldron : Tool, ISaveElement
    {
        public Cauldron() : base()
        {
            this.Name = "Cauldron";
            this.description = "";
            this.Stackable = false;
        }
        
         protected override string loadDisplayName()
         {
             return Name;
         }

         protected override string loadDescription()
         {
             return description;
         }        

         public Dictionary<string, string> getAdditionalSaveData()
         {
             Dictionary<string, string> savedata = new Dictionary<string, string>
             {
                 { "name", Name }
             };
             return savedata;
         }

         public dynamic getReplacement()
         {
             FishingRod replacement = new FishingRod();
             return replacement;
         }

         public void rebuild(Dictionary<string, string> additionalSaveData, object replacement)
         {
             this.Name = additionalSaveData["name"];
         }
    }
}
