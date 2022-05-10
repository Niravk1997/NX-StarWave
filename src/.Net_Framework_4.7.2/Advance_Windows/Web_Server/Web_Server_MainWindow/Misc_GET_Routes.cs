using MahApps.Metro.Controls;
using NX_StarWave;
using System.Threading.Tasks;
using WatsonWebserver;

namespace Waveform_Web_Server
{
    public partial class Web_Server_MainWindow : MetroWindow
    {
        static async Task DefaultRoute(HttpContext ctx)
        {
            if (Communication_Selected.is_Communication_Selected)
            {
                if (Communication_Selected.is_VISA_GPIB_Communication_Selected)
                {
                    await ctx.Response.Send("VISA");
                }
                else
                {
                    await ctx.Response.Send("AR488");
                }
            }
            else
            {
                await ctx.Response.Send("Oscilloscope is not connected.");
            }
        }
    }
}
