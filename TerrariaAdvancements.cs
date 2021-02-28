using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using TerrariaAdvancements.UI;

namespace TerrariaAdvancements
{
    public class TerrariaAdvancements : Mod
    {
        internal UserInterface ATInterface;
        internal AdvancementTreeUI ATUI;

        public static ModHotKey ToggleUIHK;

        internal void ShowUI()
        {
            ATInterface?.SetState(ATUI);
        }

        internal void HideUI()
        {
            ATInterface?.SetState(null);
        }

        public override void Load()
        {

            ToggleUIHK = RegisterHotKey("Toggle UI", "C");

            if (!Main.dedServ)
            {
                ATInterface = new UserInterface();

                ATUI = new AdvancementTreeUI();
                ATUI.Activate();
            }
        }

        private GameTime _lastUpdateUiGameTime;

        public override void UpdateUI(GameTime gameTime)
        {
            _lastUpdateUiGameTime = gameTime;
            if (ATInterface?.CurrentState != null)
            {
                ATInterface.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "TerrariaAdvancements: ATInterface",
                    delegate
                    {
                        if (_lastUpdateUiGameTime != null && ATInterface?.CurrentState != null)
                        {
                            ATInterface.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
                        }
                        return true;
                    },
                       InterfaceScaleType.UI));
            }
        }
    }
}