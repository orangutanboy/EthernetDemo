using Gadgeteer.Networking;
using NetworkModule = Gadgeteer.Modules.Module.NetworkModule;
using Gadgeteer;

namespace Demo
{
    public partial class Program
    {
        void ProgramStarted()
        {
            //The other option is UseStaticIP
            ethernet.UseDHCP();

            //Set a handler for when the network is available
            ethernet.NetworkUp += ethernet_NetworkUp;
        }

        void ethernet_NetworkUp(NetworkModule sender, NetworkModule.NetworkState state)
        {
            //Set the URI for the resource
            var url = "http://i1072.photobucket.com/albums/w367/"
                            + "M_J_O_N_E_S/MeGadgeteerSize_zps23202046.jpg?t=1373144748";

            //Create a web request
            var request = WebClient.GetFromWeb(url);

            //This is async, so set the 
            //handler for when the response received
            request.ResponseReceived += request_ResponseReceived;

            //Send the request
            request.SendRequest();
        }

        void request_ResponseReceived(HttpRequest sender, HttpResponse response)
        {
            if (response.StatusCode == "200")
            {
                //This only works if the bitmap is the 
                //same size as the screen it's flushing to
                response.Picture.MakeBitmap().Flush();
            }
            else
            {
                //Show a helpful error message
                lcd.SimpleGraphics.DisplayText("Request failed with status code " + response.StatusCode
                    , Resources.GetFont(Resources.FontResources.NinaB), Color.White, 0, 0);

                lcd.SimpleGraphics.DisplayText("Response text: " + response.Text
                       , Resources.GetFont(Resources.FontResources.NinaB), Color.White, 0, 50);

            }
        }
    }
}
