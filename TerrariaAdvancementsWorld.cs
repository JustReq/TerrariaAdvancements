using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TerrariaAdvancements
{
    public class TerrariaAdvancementsWorld : ModWorld
    {
        public bool Timber;
        public bool HammerTime;

        public override void PreUpdate()
        {
            Player player = Main.LocalPlayer;

            if (player.HasItem(ItemID.Wood) || player.HasItem(ItemID.RichMahogany) || player.HasItem(ItemID.Ebonwood) || player.HasItem(ItemID.Shadewood) || player.HasItem(ItemID.Pearlwood) || player.HasItem(ItemID.BorealWood) || player.HasItem(ItemID.PalmWood))
            {
                Timber = true;
            }

            if (player.HasItem(ItemID.WoodenHammer) || player.HasItem(ItemID.RichMahoganyHammer) || player.HasItem(ItemID.PalmWoodHammer) || player.HasItem(ItemID.BorealWoodHammer) || player.HasItem(ItemID.CopperHammer) || player.HasItem(ItemID.TinHammer) || player.HasItem(ItemID.IronHammer) || player.HasItem(ItemID.EbonwoodHammer) || player.HasItem(ItemID.ShadewoodHammer) || player.HasItem(ItemID.LeadHammer) || player.HasItem(ItemID.PearlwoodHammer) || player.HasItem(ItemID.SilverHammer) || player.HasItem(ItemID.TungstenHammer) || player.HasItem(ItemID.GoldHammer) || player.HasItem(ItemID.TheBreaker) || player.HasItem(ItemID.FleshGrinder) || player.HasItem(ItemID.PlatinumHammer) || player.HasItem(ItemID.MeteorHamaxe) || player.HasItem(ItemID.Rockfish) || player.HasItem(ItemID.MoltenHamaxe) || player.HasItem(ItemID.Pwnhammer) || player.HasItem(ItemID.Hammush) || player.HasItem(ItemID.ChlorophyteWarhammer) || player.HasItem(ItemID.SpectreHamaxe) || player.HasItem(ItemID.TheAxe))
            {
                HammerTime = true;
            }
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                [nameof(Timber)] = Timber,
                [nameof(HammerTime)] = HammerTime,
            };
        }

        public override void Load(TagCompound tag)
        {
            Timber = tag.GetBool(nameof(Timber));
            HammerTime = tag.GetBool(nameof(HammerTime));
        }
    }
}