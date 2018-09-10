# IContentCreationAPIStub
This interface will help you to create contents and sent it over to the groups like send mesage, send announcement etc.

## Functions
 - SendMessage
	This will send messages to the specified group ID. It requires groupID and SendMessageRq to send it to the group.
	If it is a flat group then this message will be visible to all and if it a Hub-spoke group then you can configure it to send it to all or specif subscribers.
	
	- Send message to all subscribers
	
		Make SendToAllSubscribers flag of SendMessageRq to true while calling SendMessage.
		```
		SendMessageRq request = new SendMessageRq();
        request.Message = "test message";
		request.SendToAllSubscribers = true;
		```
		
	- Send message to individual subscribers
		
		To Send message to individual scubscribers, you need to make SendToAllSubscribers false and then pass all the subscriber Numbers as list
		```
		SendMessageRq request = new SendMessageRq();
        request.Message = "test message";
		request.SendToAllSubscribers = false;
		List<string> numbers = new List<string>();
        numbers.Add("+91xxxxxxxxxx");
		request.Subscribers = numbers;
		```
