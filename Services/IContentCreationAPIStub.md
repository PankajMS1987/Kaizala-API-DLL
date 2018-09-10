# IContentCreationAPIStub
This interface will help you to create contents and sent it over to the groups like send mesage, send announcement etc.

## Functions
 - **SendMessage**
 
	This will send messages to the specified group ID. It requires groupID and SendMessageRq to send it to the group.
	If it is a flat group then this message will be visible to all and if it a Hub-spoke group then you can configure it to send it to all or specifc subscribers.
	
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
		
	This function returns **List<SendMessageResponse>** . If number of subscribers are less than 30 then you will receive only one SendMessageResponse otherwise multiple.
	
	On success you will receive **referenceId** otherwise errorDetails.
	
- **SendBulkMessageInSameGroup**

	If you want to send multiple messages in a single group, then use this function. you just need to provide **List<SendMessageRq>** .
	
- **SendAction**

	If you want to send Announcement then call this function with SendActionRequest and group ID. In SendActionRequest, Subscribers and SendToAllSubscribers are same as explained above.
	
	For ActionType put ActionType.ANNOUNCEMENT and AnnouncementActionBody as ActionBody as below.
	```
		SendActionRequest actionRequest = new SendActionRequest();
		actionRequest.ActionType = ActionType.ANNOUNCEMENT;
		AnnouncementActionBody actionBody = new AnnouncementActionBody();
		actionBody.Title = "Test Title";
		actionBody.Message = "Test Body";
		actionRequest.ActionBody = actionBody;

	```