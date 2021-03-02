using Terraria.GameInput;
using Terraria.ModLoader;

namespace TerrariaAdvancements
{
    public class TerrariaAdvancementsPlayer : ModPlayer
    {
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
    }
}
