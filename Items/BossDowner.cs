using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrariaAdvancements.Items
{
    public class BossDowner : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.ShadowbeamStaff;

        public override void SetDefaults()
        {
            item.color = Color.Purple;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 10;
            item.useAnimation = 10;
        }

        public override bool UseItem(Player player)
        {
            if (!NPC.downedBoss1)
            {
                NPC.downedBoss1 = true;
            }
            else
            {
                NPC.downedBoss1 = false;
            }
            return true;
        }
    }
}