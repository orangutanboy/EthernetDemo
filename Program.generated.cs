//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18047
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo {
    using Gadgeteer;
    using GTM = Gadgeteer.Modules;
    
    
    public partial class Program : Gadgeteer.Program {
        
        private Gadgeteer.Modules.GHIElectronics.UsbClientDP usbClientDP;
        
        private Gadgeteer.Modules.GHIElectronics.Display_T35 lcd;
        
        private Gadgeteer.Modules.GHIElectronics.Ethernet_J11D ethernet;
        
        public static void Main() {
            // Important to initialize the Mainboard first
            Program.Mainboard = new GHIElectronics.Gadgeteer.FEZSpider();
            Program p = new Program();
            p.InitializeModules();
            p.ProgramStarted();
            // Starts Dispatcher
            p.Run();
        }
        
        private void InitializeModules() {
            this.usbClientDP = new GTM.GHIElectronics.UsbClientDP(1);
            this.ethernet = new GTM.GHIElectronics.Ethernet_J11D(7);
            this.lcd = new GTM.GHIElectronics.Display_T35(14, 13, 12, Socket.Unused);
        }
    }
}
