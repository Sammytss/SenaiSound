using MudBlazor.Utilities;
using MudBlazor;

namespace SenaiSoundWEB.Layout
{
    public class SenaiSoundPalleta : PaletteDark
    { 
        private SenaiSoundPalleta()
        {
            Primary = new MudColor("#9966FF");
            Secondary = new MudColor("#F6AD31");
            Tertiary = new MudColor("#8AE491");
        }

        public static SenaiSoundPalleta CreatePallete => new();
    }
}

