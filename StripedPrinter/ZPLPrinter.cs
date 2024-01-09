using System.Net.Sockets;

namespace StripedPrinter;

public class ZPLPrinter
{
    private string _ipAddress { get; set; }
    private int _port { get; set; }
    
    public ZPLPrinter(string ipAddress, int port = 9100)
    {
        _ipAddress = ipAddress;
        _port = port;
    }
    
    public void Print(ZPLLabel label)
    {
        Print(label.Render());
    }
    
    public void Print(string zpl)
    {
        var client = new TcpClient();
        client.Connect(_ipAddress, _port);

        var writer = new StreamWriter(client.GetStream());
        writer.Write(zpl);
        writer.Flush();
        writer.Close();
        client.Close();
    }
}