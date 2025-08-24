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
            Helper.Events.GameLoop.UpdateTicked += UpdateTickEvent;
        }


        private void UpdateTickEvent(object sender, EventArgs e)
        {
            bool isTransferKeyPressed = Helper.Input.IsDown(Config.TransferKey.ToSButton());
            bool isTransferAllKeyPressed = Helper.Input.IsDown(Config.TransferAllKey.ToSButton());
            Transfer(isTransferKeyPressed);
            TransferAll(isTransferAllKeyPressed);
        }
        
        private void Transfer(bool keyPressed)
        {
            IList<Item> PlayerInventory = Game1.player.Items;
            if (keyPressed)
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
        }

        private void TransferAll(bool keyPressed)
        {
            IList<Item> PlayerInventory = Game1.player.Items;
            if (keyPressed)
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
                    break;
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
