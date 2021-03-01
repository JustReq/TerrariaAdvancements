using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace TerrariaAdvancements.UI
{
    public class AdvancementTreeUI : UIState
    {
        UIPanel ATPanel = new UIPanel();

        UIText HoverText = new UIText("");

        UIImageButton TerrariaCategoryButton = new UIImageButton(ModContent.GetTexture("TerrariaAdvancements/UI/Images/Categories/TerrariaCategory"));
        UIImageButton SlayerCategoryButton = new UIImageButton(ModContent.GetTexture("TerrariaAdvancements/UI/Images/Categories/SlayerCategory"));
        UIImageButton CollectorCategoryButton = new UIImageButton(ModContent.GetTexture("TerrariaAdvancements/UI/Images/Categories/CollectorCategory"));
        UIImageButton ExplorerCategoryButton = new UIImageButton(ModContent.GetTexture("TerrariaAdvancements/UI/Images/Categories/ExplorerCategory"));
        UIImageButton ChallengerCategoryButton = new UIImageButton(ModContent.GetTexture("TerrariaAdvancements/UI/Images/Categories/ChallengerCategory"));

        UIPanel TerrariaCategoryPanel = new UIPanel();
        FixedUIScrollbar TerrariaCategoryScrollbar = new FixedUIScrollbar(ModContent.GetInstance<TerrariaAdvancements>().ATInterface);

        UIImage TimberAchievement = new UIImage(ModContent.GetTexture("TerrariaAdvancements/UI/Images/Achievements/Locked/Terraria/Timber_Locked"));
        UIPanel Timber_HammerTime = new UIPanel();
        UIPanel Timber_NoHobo = new UIPanel();

        public override void OnInitialize()
        {
            ATPanel.Width.Set(500, 0);
            ATPanel.Height.Set(300, 0);
            ATPanel.HAlign = ATPanel.VAlign = 0.5f;

            TerrariaCategoryButton.Width.Set(32, 0);
            TerrariaCategoryButton.Height.Set(32, 0);
            TerrariaCategoryButton.HAlign = 0.05f;
            TerrariaCategoryButton.VAlign = 0.005f;
            // TerrariaCategoryButton.OnClick += new MouseEvent(ChallengerCategoryButtonClicked);

            SlayerCategoryButton.Width.Set(32, 0);
            SlayerCategoryButton.Height.Set(32, 0);
            SlayerCategoryButton.HAlign = 0.15f;
            SlayerCategoryButton.VAlign = 0.005f;
            // SlayerCategoryButton.OnClick += new MouseEvent(SlayerCategoryButtonClicked);

            CollectorCategoryButton.Width.Set(32, 0);
            CollectorCategoryButton.Height.Set(32, 0);
            CollectorCategoryButton.HAlign = 0.25f;
            CollectorCategoryButton.VAlign = 0.005f;
            // CollectorCategoryButton.OnClick += new MouseEvent(CollectorCategoryButtonClicked);

            ExplorerCategoryButton.Width.Set(32, 0);
            ExplorerCategoryButton.Height.Set(32, 0);
            ExplorerCategoryButton.HAlign = 0.35f;
            ExplorerCategoryButton.VAlign = 0.005f;
            // ExplorerCategoryButton.OnClick += new MouseEvent(ExplorerCategoryButtonClicked);

            ChallengerCategoryButton.Width.Set(32, 0);
            ChallengerCategoryButton.Height.Set(32, 0);
            ChallengerCategoryButton.HAlign = 0.45f;
            ChallengerCategoryButton.VAlign = 0.005f;
            // ChallengerCategoryButton.OnClick += new MouseEvent(ChallengerCategoryButtonClicked);

            TerrariaCategoryPanel.Width.Set(495, 0);
            TerrariaCategoryPanel.Height.Set(230, 0);
            TerrariaCategoryPanel.HAlign = 0.5f;
            TerrariaCategoryPanel.VAlign = 0.95f;

            TerrariaCategoryScrollbar.Height.Set(230, 0);
            TerrariaCategoryScrollbar.SetView(100f, 200f);

            TimberAchievement.Width.Set(64, 0);
            TimberAchievement.Height.Set(64, 0);
            TimberAchievement.HAlign = 0.1f;

            Timber_HammerTime.Width.Set(100, 0);
            Timber_HammerTime.Height.Set(10, 0);
            Timber_HammerTime.Left.Pixels = 63;
            Timber_HammerTime.VAlign = 0.5f;
            Timber_HammerTime.BackgroundColor = Color.Black;

            Append(ATPanel);

            Append(HoverText);

            ATPanel.Append(TerrariaCategoryButton);
            ATPanel.Append(SlayerCategoryButton);
            ATPanel.Append(CollectorCategoryButton);
            ATPanel.Append(ExplorerCategoryButton);
            ATPanel.Append(ChallengerCategoryButton);

            ATPanel.Append(TerrariaCategoryPanel);

            TerrariaCategoryPanel.Append(TerrariaCategoryScrollbar);

            TerrariaCategoryPanel.Append(TimberAchievement);
            TimberAchievement.Append(Timber_HammerTime);
        }

        public override void Update(GameTime gameTime)
        {
            Player player = Main.LocalPlayer;

            HoverText.Left.Pixels = Main.MouseScreen.X + 20f;
            HoverText.Top.Pixels = Main.MouseScreen.Y + 20f;

            if (player.GetModPlayer<TerrariaAdvancementsPlayer>().Timber != true)
            {
                HoverText.SetText("???");
                TimberAchievement.SetImage(ModContent.GetTexture("TerrariaAdvancements/UI/Images/Achievements/Locked/Terraria/Timber_Locked"));
            }
            else
            {
                TimberAchievement.SetImage(ModContent.GetTexture("TerrariaAdvancements/UI/Images/Achievements/Unlocked/Terraria/Timber_Unlocked"));
            }

            if (TerrariaCategoryButton.IsMouseHovering)
            {
                HoverText.SetText("Terraria Achievements");
            }
            else if (SlayerCategoryButton.IsMouseHovering)
            {
                HoverText.SetText("Slayer Achievements");
            }
            else if (CollectorCategoryButton.IsMouseHovering)
            {
                HoverText.SetText("Collector Achievements");
            }
            else if (ExplorerCategoryButton.IsMouseHovering)
            {
                HoverText.SetText("Explorer Achievements");
            }
            else if (ChallengerCategoryButton.IsMouseHovering)
            {
                HoverText.SetText("Challenger Achievements");
            }
            else if (TimberAchievement.IsMouseHovering)
            {
                if (player.GetModPlayer<TerrariaAdvancementsPlayer>().Timber != true)
                {
                    HoverText.SetText("???");
                }
                else
                {
                    HoverText.SetText("[c/FFD700:Timber!!]\nChop down your first tree.");
                }
            }
            else
            {
                HoverText.SetText("");
            }
        }
    }
}