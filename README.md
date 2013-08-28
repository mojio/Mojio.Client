Mojio.Client
============

In order to create our store and apps, we have built a simple C# client library to help us interact with our API. It occurred to us that maybe other people would like to develop in C# as well.  So we have published our Mojio Client on github for anyone to use and play around with!


Installation
============

Download or checkout the Mojio.Client.  You will then need to include the Mojio (Src/Mojio/Mojio.csproj) and Mojio.Client (Src/Mojio.Client/Mojio.Client.csproj) projects into your solution.  Nuget is also required to get our client working, and you will need to perform a Nuget Restore the first time you import the projects.


Getting Started
===============

To begin developing with our client, you will need your very own application ID and secret key.  First you will need to create an account and login to our developer center.  We recommend starting with our sandbox environment (http://sandbox.developer.moj.io/).

Once you have logged in, you can create a new Application.  From here, you will want to copy the Application ID and the Secret Key, these will be required to initialize the Mojio.Client.


Initializing the Client
-----------------------

To get started using the client, you must first create a new instance of the MojioClient object.  This is where you will need to pass in the Application ID and Secret Key, as well as the developer environment you are using (Sandbox, or Live).

```csharp
using Mojio.Client;

Guid appID = new Guid("{APPID}");
Guid secretKey = new Guid("{SecretKey}");

MojioClient client = new MojioClient(
                        appID, 
                        secretKey,
                        MojioClient.Sandbox // or MojioClient.Live
                    );
```

Authenticate a Mojio User
-------------------------

Now that your MojioClient is associated with your app, you can get started making some calls.  However, many of our API calls also require an authorized user to be associated with the client sesion.  In order to authenticate a user, you must pass in the users name or email along with their password.

```csharp
// ...
// Authenticate specific user
client.SetUser( "demo@example.com", "mypassword");
	
// ...
// Logout user.
client.Logout();
```

Fetching Data
-------------

To retrieve a set of a particular Mojio entities, you can use the "Get" method.  The returned results will depend on what user and application your client session is authorized as. Lists of data will be returned in a paginated form.  You are able to set the page size and request a particular page.  In order to keep response times fast, it is recommended to keep the page size low.

```csharp
// ...
// Set default page size
client.PageSize = 15;
	
// Fetch first page of 15 trips
Results<Trip> results = client.Get<Trip>();
	
// Iterate over each trip
foreach( Trip trip in results.Data )
{
     // Do something with each trip
     // ...
}
```

Fetch a specific Entity
-----------------------

By passing in the ID of an entity (often a GUID), you can fetch just that single entity from the database.

```csharp
// ...
string mojioId = "123451234512345"; // Mojio IMEI
	
// Fetch mojio from API
Device mojio = client.Get<Device>(mojioId);
	
// Do something with the mojio data
// ...
```

Update an Entity
----------------

If you want to update and save an entity, you need to first load the entity from the API, make your changes, and then save it back.  Typically only the owner of an entity will be authorized to save changes and not all properties of an entity will be editable (for example, for an App, only the Name and Description properties can be changed).

```csharp
// ...
Device mojio = client.Get<Device>("123451234512345");

// Make a change
mojio.Name = "New Name";

// Save the changes
client.Update(mojio);
```

Get a list of child entities
----------------------------

If you want to fetch all the entities associated with another entity, you can call the GetBy method.  For example, if you want to fetch all the events associated with a mojio device.

```csharp
// ...
string mojioId = "123451234512345";

// Fetch all events by mojio ID
Results<Event> events = client.GetBy<Event,Device>(mojioId);

//Or, alternatively
Device mojio = client.Get<Device>(mojioId);
Results<Event> events = client.GetBy<Event>(mojio);

// ...
```

Using the Mojio Storage
-----------------------

With the Mojio API, you are able to store your own private data within our database as key value pairs.  These key value pairs will only be accessible by your application, and you can associate them with any Mojio entities (ex: Mojio Device, Application, User, Trip, Event, Invoice, Product).

```csharp
// ...
Guid userId = new Guid("0a5453a0-7e70-16d1-a2w6-28dl98c10200");  // Some user's ID
string key = "EyeColour";	// Key to store
string value = "Brown"; 	// Value to store

// Save user's eye colour
client.SetStored<User>( userId, key , value );
	
// ...
// Retrieve user's eye colour
String stored = client.GetStore<User>( userId, key );
```

Using SignalR to listen for events
----------------------------------

Instead of continuously polling the API to see if any new events have come in, our API has a signalR service you can subscribe to in order to be sent new event notifications as they happen.

```csharp
    // ...
    // The Mojio ID you wish to listen to
    Guid mojioId = "123451234512345";
	
    // An array of event types you wish to be notified about
    EventType[] types = new EventType[] { EventType.GPS, EventType.Tow };

    // Setup the callback function
    public void ReceiveEvent(Event event)
    {
        if( event.EventType == EventType.GPS)
            // A new GPS event was received!
            // ...
        else if( event.EventType == EventType.Tow )
            // Do something with the new tow alert
            // ...
    }

    client.EventHandler += ReceiveEvent;            // Binds the event listener
    client.Subscribe&lt;Device&gt;(mojioId,types);   // Register subscrition

    // ...
    // Unsubscribe
    client.Unsubscribe&lt;Device&gt;(mojioId,types);
```
