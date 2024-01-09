using System.Net.Sockets;

namespace StripedPrinter;

public class ZPLPrinter(string ipAddress, int port = 9100)
{
    public void Print(ZPLLabel label)
    {
        Print(label.Render());
    }
    
    public void Print(string zpl)
    {
        var client = new TcpClient();
        client.Connect(ipAddress, port);

        var writer = new StreamWriter(client.GetStream());
        writer.Write(zpl);
        writer.Flush();
        writer.Close();
        client.Close();
    }
}