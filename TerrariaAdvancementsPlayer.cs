using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrariaAdvancements
{
    public class TerrariaAdvancementsPlayer : ModPlayer
    {
        public bool Timber;

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (TerrariaAdvancements.ToggleUIHK.JustPressed)
            {
                if (ModContent.GetInstance<TerrariaAdvancements>().ATInterface.CurrentState == null)
                {
                    ModContent.GetInstance<TerrariaAdvancements>().ShowUI();
                }
                else
                {
                    ModContent.GetInstance<TerrariaAdvancements>().HideUI();
                }
            }
        }

        public override void PreUpdate()
        {
            if (player.HasItem(ItemID.Wood) || player.HasItem(ItemID.RichMahogany) || player.HasItem(ItemID.Ebonwood) || player.HasItem(ItemID.Shadewood) || player.HasItem(ItemID.Pearlwood) || player.HasItem(ItemID.BorealWood) || player.HasItem(ItemID.PalmWood))
            {
                Timber = true;
            }
        }
    }
}
