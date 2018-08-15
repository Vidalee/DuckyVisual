using System;
using System.Linq;
using System.Threading;

namespace DuckyVisual
{
    class Program
    {
        public static HIDDevice device = null;
        public static DuckyInterface di;

        static void OnProcessExit(object sender, EventArgs e)
        {
            //Tell the keyboard to return to a normal state.
            //This is only triggered if the user peacefully terminate the program !! (hint: press enter in the console)
            if (device != null)
            {
                di.SendClosePayload();
                device.close();
            }
        }

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            HIDDevice.interfaceDetails[] devices = HIDDevice.getConnectedDevices();

            //Select Ducky Shine 6 keyboard, with the 01 interface, the one used for software connection
            string devicePath = null;
            try
            {
                devicePath = devices.Where(dev => dev.devicePath.Contains("vid_04d9&pid_0203&mi_01")).First().devicePath;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Make sure your keyboard is connected !");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Please DO NOT close this program by clicking on the red cross/closing it rudely, or your keyboard will stay on control mode." +
                " Just press enter here once you're done.");

            //Create a handle to the device by calling the constructor
            device = new HIDDevice(devicePath, false);

            di = new DuckyInterface(device);

            //Press enter to safely exit the program..
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Console.ReadLine();
                di.SendClosePayload();
                device.close();
                Environment.Exit(4);
            }).Start();

            //Instanciate the web server

            Thread.CurrentThread.IsBackground = true;
            HTTPServer server = new HTTPServer(di);
           

        }
    }
}
