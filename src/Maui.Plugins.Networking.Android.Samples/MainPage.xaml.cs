using System.Collections.ObjectModel;
using System.Net;
using System.Text;

namespace Maui.Plugins.Networking.Android.Samples;

public partial class MainPage : ContentPage
{
    private bool isBusy;
    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
        ConsoleWriter.ConsoleDisplay = ConsoleDisplay;
        PingBtn.Clicked += PingBtn_Clicked;
        PortScanBtn.Clicked += PortScanBtn_Clicked;
        WakeOnLanBtn.Clicked += WakeOnLanBtn_Clicked;
        SubnetDevicesBtn.Clicked += SubnetDevicesBtn_Clicked;
        MacAddressBtn.Clicked += MacAddressBtn_Clicked;
    }



    private void MacAddressBtn_Clicked(object sender, EventArgs e)
    {
        if (isBusy) return;
        isBusy = true;
        try
        {
#if ANDROID
            var ip = NetworkUtils.GetLocalIpv4Address();
            //Support until API 29
            var mac = NetworkUtils.GetMacAddressFromIp(ip.HostAddress);

            ConsoleWriter.WriteLine("MAC Address: " + mac);
#endif
        }
        catch (Exception ex)
        {
            ConsoleWriter.WriteError(ex);
        }
        finally
        {
            isBusy = false;
        }
    }

    private async void SubnetDevicesBtn_Clicked(object sender, EventArgs e)
    {
        if (isBusy) return;
        isBusy = true;
        try
        {
#if ANDROID
            ConsoleWriter.WriteLine("Searching...");
            //var foundDevices = await SubnetScanner.Instance.FindDevicesAsync();
            var foundDevices = await SubnetScanner.Instance.FindDeviceByIpAsync(ipText.Text);

            ConsoleWriter.WriteCollectionToConsole("Found Devices: ", foundDevices);
#else
            await Task.CompletedTask;
#endif
        }
        catch (Exception ex)
        {
            ConsoleWriter.WriteError(ex);
        }
        finally
        {
            isBusy = false;
        }
    }

    private async void WakeOnLanBtn_Clicked(object sender, EventArgs e)
    {
        if (isBusy) return;
        isBusy = true;
        try
        {
#if ANDROID
            //Search specific ports
            var foundPorts = await PortScanner.Instance.ScanAsync(ipText.Text, [10, 20, 80, 90], 1000, Enums.TransportType.Tcp);
            //Search all available ports
            //var foundPorts = await PortScanner.Instance.ScanAsync(ipText.Text, null, 1000, Enums.TransportType.Tcp);

            ConsoleWriter.WriteLine("PortScanner Result: ");
            foreach (var foundPort in foundPorts)
            {
                ConsoleWriter.WriteLine("Found: " + foundPort);
                ConsoleWriter.WriteLine();
            }
#else
            await Task.CompletedTask;
#endif
        }
        catch (Exception ex)
        {
            ConsoleDisplay.Text += ex.Message + "\n" + ex.StackTrace;
        }
        finally
        {
            isBusy = false;
        }
    }

    private async void PortScanBtn_Clicked(object sender, EventArgs e)
    {
        if (isBusy) return;
        isBusy = true;
        try
        {
#if ANDROID
            ConsoleWriter.WriteLine("Searching...");
            //Search specific ports
            var foundPorts = await PortScanner.Instance.ScanAsync(ipText.Text, [10, 20, 80, 90], 1000, Enums.TransportType.Tcp);
            //Search all available ports
            //var foundPorts = await PortScanner.Instance.ScanAsync(ipText.Text, null, 1000, Enums.TransportType.Tcp);

            ConsoleWriter.WriteLine("PortScanner Result: ");
            foreach (var foundPort in foundPorts)
            {
                ConsoleWriter.WriteLine("Found: " + foundPort);
                ConsoleWriter.WriteLine();
            }
#else
            await Task.CompletedTask;
#endif
        }
        catch (Exception ex)
        {
            ConsoleDisplay.Text += ex.Message + "\n" + ex.StackTrace;
        }
        finally
        {
            isBusy = false;
        }
    }

    private async void PingBtn_Clicked(object sender, EventArgs e)
    {
        if (isBusy) return;
        isBusy = true;
        try
        {
#if ANDROID
            ConsoleWriter.WriteLine("Pinging...");
            //Ping ip
            var result = await Pinger.Instance.PingAsync(ipText.Text, pingCount: 20);

            ConsoleWriter.WriteObjectToConsole("Ping Result: ", result);
            ConsoleWriter.WriteCollectionToConsole(null, result.Attempts);
#else
            await Task.CompletedTask;
#endif
        }
        catch (Exception ex)
        {
            ConsoleWriter.WriteError(ex);
        }
        finally
        {
            isBusy = false;
        }
    }
    
}
