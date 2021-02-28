using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace TerrariaAdvancements.UI
{
    public class ATHoverImageButton : UIImageButton
    {
        internal string HoverText;

        public ATHoverImageButton(Texture2D texture, string hoverText) : base(texture)
        {
            HoverText = hoverText;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            if (IsMouseHovering)
            {
                Main.hoverItemName = HoverText;
            }
        }
    }

    public class ATHoverImage : UIImage
    {
        internal string HoverText;

        public ATHoverImage(Texture2D texture, string hoverText) : base(texture)
        {
            HoverText = hoverText;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            if (IsMouseHovering)
            {
                Main.hoverItemName = HoverText;
            }
        }
    }

    public class AdvancementTreeUI : UIState
    {
        public ATHoverImageButton HoverImageButton;

        ATHoverImage EyeOnYou_Achievement;

        UIPanel SlayerCategoryPanel;

        Texture2D EyeOnYou_LockedTexture = ModContent.GetTexture("TerrariaAdvancements/UI/Images/Achievements/Locked/Slayer/EyeOnYou_Locked");
        Texture2D EyeOnYou_UnlockedTexture = ModContent.GetTexture("TerrariaAdvancements/UI/Images/Achievements/Unlocked/Slayer/EyeOnYou_Unlocked");

        public override void OnInitialize()
        {
            UIPanel ATPanel = new UIPanel();
            ATPanel.Width.Set(500, 0);
            ATPanel.Height.Set(300, 0);
            ATPanel.HAlign = ATPanel.VAlign = 0.5f;
            Append(ATPanel);

            Texture2D TerrariaCategoryTexture = ModContent.GetTexture("TerrariaAdvancements/UI/Images/Categories/TerrariaCategory");
            ATHoverImageButton TerrariaCategoryButton = new ATHoverImageButton(TerrariaCategoryTexture, "Terraria Achievements");
            TerrariaCategoryButton.Width.Set(32, 0);
            TerrariaCategoryButton.Height.Set(32, 0);
            TerrariaCategoryButton.HAlign = 0.05f;
            TerrariaCategoryButton.VAlign = 0.005f;
            // ChallengerCategoryButton.OnClick += new MouseEvent(ChallengerCategoryButtonClicked);
            ATPanel.Append(TerrariaCategoryButton);

            Texture2D SlayerCategoryTexture = ModContent.GetTexture("TerrariaAdvancements/UI/Images/Categories/SlayerCategory");
            ATHoverImageButton SlayerCategoryButton = new ATHoverImageButton(SlayerCategoryTexture, "Slayer Achievements");
            SlayerCategoryButton.Width.Set(32, 0);
            SlayerCategoryButton.Height.Set(32, 0);
            SlayerCategoryButton.HAlign = 0.15f;
            SlayerCategoryButton.VAlign = 0.005f;
            // SlayerCategoryButton.OnClick += new MouseEvent(SlayerCategoryButtonClicked);
            ATPanel.Append(SlayerCategoryButton);

            Texture2D CollectorCategoryTexture = ModContent.GetTexture("TerrariaAdvancements/UI/Images/Categories/CollectorCategory");
            ATHoverImageButton CollectorCategoryButton = new ATHoverImageButton(CollectorCategoryTexture, "Collector Achievements");
            CollectorCategoryButton.Width.Set(32, 0);
            CollectorCategoryButton.Height.Set(32, 0);
            CollectorCategoryButton.HAlign = 0.25f;
            CollectorCategoryButton.VAlign = 0.005f;
            // CollectorCategoryButton.OnClick += new MouseEvent(CollectorCategoryButtonClicked);
            ATPanel.Append(CollectorCategoryButton);

            Texture2D ExplorerCategoryTexture = ModContent.GetTexture("TerrariaAdvancements/UI/Images/Categories/ExplorerCategory");
            ATHoverImageButton ExplorerCategoryButton = new ATHoverImageButton(ExplorerCategoryTexture, "Explorer Achievements");
            ExplorerCategoryButton.Width.Set(32, 0);
            ExplorerCategoryButton.Height.Set(32, 0);
            ExplorerCategoryButton.HAlign = 0.35f;
            ExplorerCategoryButton.VAlign = 0.005f;
            // ExplorerCategoryButton.OnClick += new MouseEvent(ExplorerCategoryButtonClicked);
            ATPanel.Append(ExplorerCategoryButton);

            Texture2D ChallengerCategoryTexture = ModContent.GetTexture("TerrariaAdvancements/UI/Images/Categories/ChallengerCategory");
            ATHoverImageButton ChallengerCategoryButton = new ATHoverImageButton(ChallengerCategoryTexture, "Challenger Achievements");
            ChallengerCategoryButton.Width.Set(32, 0);
            ChallengerCategoryButton.Height.Set(32, 0);
            ChallengerCategoryButton.HAlign = 0.45f;
            ChallengerCategoryButton.VAlign = 0.005f;
            // ChallengerCategoryButton.OnClick += new MouseEvent(ChallengerCategoryButtonClicked);
            ATPanel.Append(ChallengerCategoryButton);

            UIPanel SlayerCategoryPanel = new UIPanel();
            SlayerCategoryPanel.Width.Set(495, 0);
            SlayerCategoryPanel.Height.Set(230, 0);
            SlayerCategoryPanel.HAlign = 0.5f;
            SlayerCategoryPanel.VAlign = 0.95f;
            ATPanel.Append(SlayerCategoryPanel);

            UIScrollbar ATScrollbar = new FixedUIScrollbar(ModContent.GetInstance<TerrariaAdvancements>().ATInterface);
            ATScrollbar.Height.Set(230, 0);
            ATScrollbar.SetView(100f, 200f);
            SlayerCategoryPanel.Append(ATScrollbar);

            ATHoverImage EyeOnYou_Achievement = new ATHoverImage(EyeOnYou_LockedTexture, "???");
            EyeOnYou_Achievement.Width.Set(64, 0);
            EyeOnYou_Achievement.Height.Set(64, 0);
            EyeOnYou_Achievement.HAlign = 0.1f;

            if (NPC.downedBoss1)
            {
                EyeOnYou_Achievement.SetImage(EyeOnYou_UnlockedTexture);
                EyeOnYou_Achievement.HoverText = "Dingus";
            }
            else
            {
                EyeOnYou_Achievement.SetImage(EyeOnYou_LockedTexture);
                EyeOnYou_Achievement.HoverText = "???";
            }
            SlayerCategoryPanel.Append(EyeOnYou_Achievement);
        }

        public override void Update(GameTime gameTime)
        {
            if (NPC.downedBoss1)
            {
                Main.NewText("Down");
                // EyeOnYou_Achievement.SetImage(EyeOnYou_UnlockedTexture);
                // EyeOnYou_Achievement.HoverText = "Dingus";
            }
            else
            {
                Main.NewText("Not Down");
                // EyeOnYou_Achievement.SetImage(EyeOnYou_LockedTexture);
                // EyeOnYou_Achievement.HoverText = "???";
            }
        }
    }
}