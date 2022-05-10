using MahApps.Metro.Controls;
using Newtonsoft.Json;
using NX_StarWave.Waveform_Model_Classes;
using System.Threading.Tasks;
using WatsonWebserver;

namespace Waveform_Web_Server
{
    public partial class Web_Server_MainWindow : MetroWindow
    {
        private readonly static Wavefrom_Web_Server_Model_Class Blank_Waveform = new Wavefrom_Web_Server_Model_Class(false, 0, 0, 0, 0, 0, "", new double[] { 0 });

        private static string CH1_Counter_String = "0";
        private static int CH1_Counter_ = 0;
        public static int CH1_Counter
        {
            get { return CH1_Counter_; }
            set
            {
                CH1_Counter_ = value;
                CH1_Counter_String = value.ToString();
            }
        }

        private static string CH1_Waveform_ = JsonConvert.SerializeObject(Blank_Waveform);
        public static string CH1_Waveform
        {
            get { return CH1_Waveform_; }
            set
            {
                CH1_Waveform_ = value;
            }
        }

        private static string CH2_Counter_String = "0";
        private static int CH2_Counter_ = 0;
        public static int CH2_Counter
        {
            get { return CH2_Counter_; }
            set
            {
                CH2_Counter_ = value;
                CH2_Counter_String = value.ToString();
            }
        }

        private static string CH2_Waveform_ = JsonConvert.SerializeObject(Blank_Waveform);
        public static string CH2_Waveform
        {
            get { return CH2_Waveform_; }
            set
            {
                CH2_Waveform_ = value;
            }
        }

        private static string CH3_Counter_String = "0";
        private static int CH3_Counter_ = 0;
        public static int CH3_Counter
        {
            get { return CH3_Counter_; }
            set
            {
                CH3_Counter_ = value;
                CH3_Counter_String = value.ToString();
            }
        }

        private static string CH3_Waveform_ = JsonConvert.SerializeObject(Blank_Waveform);
        public static string CH3_Waveform
        {
            get { return CH3_Waveform_; }
            set
            {
                CH3_Waveform_ = value;
            }
        }

        private static string CH4_Counter_String = "0";
        private static int CH4_Counter_ = 0;
        public static int CH4_Counter
        {
            get { return CH4_Counter_; }
            set
            {
                CH4_Counter_ = value;
                CH4_Counter_String = value.ToString();
            }
        }

        private static string CH4_Waveform_ = JsonConvert.SerializeObject(Blank_Waveform);
        public static string CH4_Waveform
        {
            get { return CH4_Waveform_; }
            set
            {
                CH4_Waveform_ = value;
            }
        }

        [StaticRoute(HttpMethod.GET, "/CH1_Counter")]
        public static async Task CH1_Counter_GET(HttpContext ctx)
        {
            await ctx.Response.Send(CH1_Counter_String);
        }

        [StaticRoute(HttpMethod.GET, "/CH1")]
        public static async Task CH1_Waveform_GET(HttpContext ctx)
        {
            await ctx.Response.Send(CH1_Waveform);
        }

        [StaticRoute(HttpMethod.GET, "/CH2_Counter")]
        public static async Task CH2_Counter_GET(HttpContext ctx)
        {
            await ctx.Response.Send(CH2_Counter_String);
        }

        [StaticRoute(HttpMethod.GET, "/CH2")]
        public static async Task CH2_Waveform_GET(HttpContext ctx)
        {
            await ctx.Response.Send(CH2_Waveform);
        }

        [StaticRoute(HttpMethod.GET, "/CH3_Counter")]
        public static async Task CH3_Counter_GET(HttpContext ctx)
        {
            await ctx.Response.Send(CH3_Counter_String);
        }

        [StaticRoute(HttpMethod.GET, "/CH3")]
        public static async Task CH3_Waveform_GET(HttpContext ctx)
        {
            await ctx.Response.Send(CH3_Waveform);
        }

        [StaticRoute(HttpMethod.GET, "/CH4_Counter")]
        public static async Task CH4_Counter_GET(HttpContext ctx)
        {
            await ctx.Response.Send(CH4_Counter_String);
        }

        [StaticRoute(HttpMethod.GET, "/CH4")]
        public static async Task CH4_Waveform_GET(HttpContext ctx)
        {
            await ctx.Response.Send(CH4_Waveform);
        }
    }
}
