using System;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Objects;
using Netcode;
using System.Collections.Generic;

namespace EasyItemTransfer
{
    public class EasyItemTransfer : Mod
    {

        public EasyItemTransferConfig Config { get; set; }

        public override void Entry(IModHelper helper)
        {
            Config = helper.ReadConfig<EasyItemTransferConfig>();
            GameEvents.UpdateTick += UpdateTickEvent;

        }


        private void UpdateTickEvent(object sender, EventArgs e)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();
            KeyUp(currentKeyboardState);
        }
        
        private void KeyUp(KeyboardState currentKeyboardState)
        {

            IList<Item> PlayerInventory = Game1.player.Items;

            if (currentKeyboardState.IsKeyDown(this.Config.transferKey))
            {
                Chest OpenChest = GetOpenChest();
                if (OpenChest == null)
                    return;


                if (OpenChest.isEmpty())
                    return;

                NetObjectList<Item> OpenChestItems = OpenChest.items;
                foreach (Item chestItem in OpenChestItems)
                {
                    foreach (Item playerItem in PlayerInventory)
                    {
                        if (playerItem != null)
                        {
                            if (playerItem.canStackWith(chestItem))
                            {
                                OpenChest.grabItemFromInventory(playerItem, Game1.player);
                                break;
                            }
                        }
                    }
                }
            }

            
            if (currentKeyboardState.IsKeyDown(this.Config.transferAllKey))
            {
                Chest OpenChest = GetOpenChest();
                if (OpenChest == null)
                    return;

                foreach (Item playerItem in PlayerInventory)
                {
                    if (playerItem == null)
                        continue;

                    if (OpenChest.items.Count > 35)
                        continue;

                    OpenChest.grabItemFromInventory(playerItem, Game1.player);
                    {
                        break;
                    }                    
                }
            }
        }

        private static Chest GetOpenChest()
        {
            if (Game1.activeClickableMenu == null)
            {
                return null;
            }

            if (Game1.activeClickableMenu is StardewValley.Menus.ItemGrabMenu)
            {
                StardewValley.Menus.ItemGrabMenu menu = Game1.activeClickableMenu as StardewValley.Menus.ItemGrabMenu;
                if (menu.behaviorOnItemGrab != null && menu.behaviorOnItemGrab.Target is Chest)
                {
                    return menu.behaviorOnItemGrab.Target as Chest;
                }
            }
            return null;
        }
    }
    
}
