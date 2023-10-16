# Twitch IRC Message Counter
## Description
This program is a Twitch IRC bot built with .NET 8.0 that listens to messages on a Twitch channel and performs specific actions when the following conditions are met:

When a message containing "ShiraMelonSoda" is detected, it increments a counter value stored in a file named counter.txt.
When a message containing "!soda" is detected, it sends the current value of the counter as a message back to the Twitch IRC channel.
## Installation
Clone the Repository: Begin by cloning this repository to your local machine using the following command:
```
git clone https://github.com/WSzoda/TwitchChatBot.git
```
Build the Project: Open the solution file in Visual Studio or use the command line to build the project:
```
dotnet restore
dotnet build
```
Configuration
Before running the program, you need to configure the Twitch IRC connection settings. Create a appsetings.json file in the project directory with the following structure:
```
{
  "ApiSettings": {
    "client_id": "",
    "secret_id": "",
    "oauth": ""
  }
}
```
Replace the placeholder values with your specific client_id, secret_id, and OAuth token. You can obtain an OAuth token for your bot on the Twitch Developer portal. Also update username and channel name in Program.cs

Usage
After configuring the appsetings.json file, you can run the program using the following command:
```
dotnet run
```
The program will connect to the specified Twitch IRC channel and begin listening for messages. When a message containing "ShiraMelonSoda" is detected, it will increment the value in the counter.txt file. If a message containing "!soda" is received, it will send the current value of the counter to the channel.
