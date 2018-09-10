# KaizalaSession
KaizalaSession internally manages AcctionToken. If token gets expired then it regenerates it again.

## Functions
  - **GetContentCreationAPIStub**
  
  It returns IContentCreationAPIStub to create contents and send it. you can find more details [Here](https://github.com/PankajMS1987/Kaizala-API-DLL/blob/master/Services/IContentCreationAPIStub.md)

- **BotUser APIs**

You can manage bot users via KaizalaSession. Below are the functions to manage it.

    - GetBotUsers

    This will return all the bot users

    - CreateBotUser

    This will create a new Bot User. After a successfull call you will receive botUserid. Use the same botUserID for further use.

    - AddBotUserToGroup

    You need to first add Bot User to the group then only bot will be able to send messages.

    - DeleteBotUser

      It will delete you existing bot user

    - UpdateBotUser

    It will update you Bot User details.

    - GetBotUserSession

  It will return **BotUserSession**. With this BotUserSession you can get IContentCreationAPIStub and start sending messages.
