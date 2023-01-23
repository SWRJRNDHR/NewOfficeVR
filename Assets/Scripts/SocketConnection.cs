using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class SocketConnection : MonoBehaviour
{
    private Socket socket;
    float time;
    float Delay;

    private void Start()
    {
        time = 0f;
        Delay = 30f;

        // Create a socket and bind it to the IP address and port
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234));
        socket.Listen(1);

        // Accept incoming connections
        
    }

    void Update()
    {
        time = time + 1f * Time.deltaTime;

        if (time >= Delay)
        {
            socket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }
    }


        private void AcceptCallback(IAsyncResult ar)
    {
        // Get the socket for the incoming connection
        Socket clientSocket = socket.EndAccept(ar);

        // Receive data from the client
        byte[] data = new byte[1024];
        int bytesReceived = clientSocket.Receive(data);
        Debug.Log("Received: " + bytesReceived);
        string message = System.Text.Encoding.ASCII.GetString(data, 0, bytesReceived);

        // Print the received message
        Debug.Log("Received: " + message);

        
        // Close the socket
        clientSocket.Close();
            

    }
}