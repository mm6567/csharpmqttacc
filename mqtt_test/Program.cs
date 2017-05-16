using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace mqtt_test
{
	class Program // simple M2Mqtt example is from https://github.com/eclipse/paho.mqtt.m2mqtt/wiki/Simple-Subscribe-Example
	{
		static void Main(string[] args)
		{
			System.Console.WriteLine("Hello, World!");
			// Create Client instance
			MqttClient myClient = new MqttClient("127.0.0.1");

			// Register to message received
			myClient.MqttMsgPublishReceived += client_recievedMessage;

			string clientId = Guid.NewGuid().ToString();
			myClient.Connect(clientId);

			// Subscribe to topic
			myClient.Subscribe(new String[] { "#" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
			System.Console.ReadLine();
		}


		static void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
		{
			// Handle message received
			var message = System.Text.Encoding.Default.GetString(e.Message);
			System.Console.WriteLine("Message received: " + message);
		}
	}
}
