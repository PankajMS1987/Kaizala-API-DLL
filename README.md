# Kaizala-API-DLL
This repository contains C# dll to make API call to Kaizala server and perform specefied actions like sending message to a group.

## Prerequisites:
- Need Newtonsoft.Json library
- System.Net.Http.Formatting

## To Send Text message in a group:
- To make any API Call you first need to create a session and pass your **ApplicationId**, **ApplicationSecret** and **RefreshToken** like below
  ```
  KaizalaSession ks = KaizalaSessionFactory.GetKaizalaSession(appId, appSecret, refreshToken);
  ```
  To create connector please follow https://docs.microsoft.com/en-us/kaizala/connectors/setup.
  
  **KaizalaSession** internally generates and keeps AccessToken. It eventually pass it during API Calls.
  
- To send messages you need to get **IContentCreationAPIStub** from KaizalaSession

  ```
  IContentCreationAPIStub creationApi = ks.GetContentCreationAPIStub();
  ```
  
- Prepare **SendMessageRq** with proper details like Message, Subscriber numbers(optional) etc like

  ```
  SendMessageRq request = new SendMessageRq();
  
  request.Message = "test message";
  
  List<string> numbers = new List<string>();
  
  //Subscriber Number
  numbers.Add("+91**********");
  
  request.Subscribers = numbers;
  ```
- Call **SendMessage** of **IContentCreationAPIStub** and pass **SendMessageRq** and Group ID to send message in a group
  ```
  List<SendMessageResponse> task = creationApi.SendMessage(groupId, request);
  ```
  Returns List of **SendMessageResponse**. It First try to accomodate all subscribers in one request but if Subscribers Counts goes beyond 30 then it sends message in 
  chunks of 30 Subscribers.
  
  If Message went through, you will get referenceId otherwise Error ResponseCode
