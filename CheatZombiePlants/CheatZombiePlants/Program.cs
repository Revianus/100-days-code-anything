using ImGuiNET;
using ClickableTransparentOverlay;
using Swed32;

namespace CheatZombiePlants
{
    public class Program : Overlay
    {
        bool unlimitedSun = false;
        IntPtr moduleBase;
        int sunValueAddress = 0x1F636; // Addess Nya
        Swed swed = new Swed("popcapgame1");

        protected override void Render()
        {
            ImGui.Begin("Made By revvxz");
            ImGui.Checkbox("Unlimited Bunga Matahari", ref unlimitedSun);
            ImGui.End();
        }

        public void Hacklogic()
        {
            moduleBase = swed.GetModuleBase(".exe");

            while (true)
            {
                if (unlimitedSun)
                {
                    swed.WriteBytes(moduleBase, sunValueAddress, "90 90 90 90 90 90");
                }
                else
                {
                    swed.WriteBytes(moduleBase, sunValueAddress, "89 B7 78 55 00 00");
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Injected");
            Program program = new Program();
            program.Start().Wait();
            Thread hackThread = new Thread(program.Hacklogic) { IsBackground = true };
            hackThread.Start();
        }
    }
}