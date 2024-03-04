public class Socket {

    public string IP { get; set; }
    public ushort Port { get; set; }

    public Socket(string ip, ushort port) {
        this.IP = ip;
        this.Port = port;
    }

    public void Deconstruct(out string ip, out ushort port) {
        ip = this.IP;
        port = this.Port;
    }

    public override string ToString() {
        return $"Socket - {IP}:{Port}";
    }
}

public record SocketRecord(string IP, ushort Port);


// Socket
{
    var s = new Socket("123.123.123.123", 12345);
    Console.WriteLine(s);

    var (ip, port) = s;
    Console.WriteLine(ip);
    Console.WriteLine(port);
}

// SocketRecord
{
    var sr = new SocketRecord("223.223.223.223", 54321);
    Console.WriteLine(sr);

    var (ip, port) = sr;
    Console.WriteLine(ip);
    Console.WriteLine(port);
}

