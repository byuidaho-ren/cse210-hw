<h3> Program 1: YouTube Videos – Design Overview </h3>
What Does the Program Do?
This program simulates a basic YouTube-like platform with the ability to:

Create a channel

Add videos to a channel
Play a video (increases view count)
View detailed video information
List all videos within a channel

It demonstrates abstraction by hiding how the video system works internally and exposing only relevant methods (e.g., Play(), AddVideo(), GetDetails()).

Candidate Classes & Responsibilities
Class	Purpose / Responsibility
Video	Represents a single video: handles its metadata (title, duration, views, channel name) and behavior (play, display info)
Channel	Represents a YouTube channel: stores a list of Video objects and manages them
Program	The entry point of the application: simulates creating channels, adding videos, and user interaction

Class Details and Video Class
Attributes:

Title: string — Title of the video
Duration: int — Length in seconds
Views: int — View count
ChannelName: string — Name of the publishing channel

Methods:
Play() — Increments view count and displays a message
GetDetails() — Displays video metadata and current timestamp

Channel Class
Attributes:
Name: string — Name of the channel
Videos: List<Video> — Collection of videos published by this channel

Methods:
AddVideo(Video) — Adds a video to the channel
ShowVideos() — Lists all video titles in the channel with timestamps


```pgsql 

+-----------------------+
|        Video          |
+-----------------------+
| - Title: string       |
| - Duration: int       |
| - Views: int          |
| - ChannelName: string |
+-----------------------+
| + Play(): void        |
| + GetDetails(): void  |
+-----------------------+

+-------------------------+
|        Channel          |
+-------------------------+
| - Name: string          |
| - Videos: List<Video>   |
+-------------------------+
| + AddVideo(video): void |
| + ShowVideos(): void    |
+-------------------------+

+----------------------+
|      Program         |
+----------------------+
| + Main(args): void   |
+----------------------+

```

<h5> Program Flow Overview </h5> 

A Channel is created.

One or more Video objects are created and associated with that channel.
Videos are added to the channel via AddVideo().
A video is played using Play(), which increases its Views.
Video details are printed using GetDetails().
The channel’s videos are listed using ShowVideos().


<br>
<hr>
<br>

<h5> Program Overview: What Does the Program Do? </h5>
This program simulates a basic e-commerce ordering system. 

<br>It:
<br>Creates products with prices and stock.
<br>Stores customers and their addresses.
<br>Allows customers to place orders containing multiple items.
<br>Updates stock when orders are placed.
<br>Calculates total cost and provides order summaries, packing, and shipping labels.
<br>Supports order status updates (e.g., "Pending", "Shipped").
<br>

<h5>Candidates for Classes</h5>
The design includes six well-defined classes:
<br>Address
<br>Customer
<br>Product
<br>OrderItem
<br>Order
<br>Program (main execution)
<br>

<h5>Responsibilities of Each Class</h5>
Class	Responsibilities
<br>Address	Store and return full address details.
<br>Customer	Store and provide customer name and address.
<br>Product	Store product info (name, price, stock); manage stock updates.
<br>OrderItem	Represent a product in an order with quantity; compute total price.
<br>Order	Manage list of order items, associate with customer, handle order status, calculate total, and generate labels.
<br>Program	Create and tie everything together; simulate real-world usage.
<br>

<h5>Determine Behaviors and Methods</h5>
Class	Methods (Behaviors)
<br>Address	GetFullAddress()
<br>Customer	GetName(), GetAddress()
<br>Product	ReduceStock(int), Restock(int)
<br>OrderItem	GetTotalPrice()
<br>Order	AddItem(Product, int), CalculateTotal(), UpdateStatus(string), ShowOrder(), GetPackingLabel(), GetShippingLabel()
<br>

<h5>Determine Attributes (Member Variables)</h5>
Class	Attributes (Member Variables)
<br>Address	_street, _city, _state, _postalCode
<br>Customer	_name, _address
<br>Product	_name, _price, _stock
<br>OrderItem	_product, _quantity
<br>Order	_items, _orderId, _status, _customer


Class Diagram (UML-Style Summary)

```pgsql

// Address
+----------------+
|    Address     |
+----------------+
| - _street      |
| - _city        |
| - _state       |
| - _postalCode  |
+----------------+
| + GetFullAddress() : string |
+----------------+


```

```pgsql

// Customer
+----------------+
|   Customer     |
+----------------+
| - _name        |
| - _address     |
+----------------+
| + GetName() : string        |
| + GetAddress() : Address    |
+----------------+

```

```pgsql

// Product
+----------------+
|    Product     |
+----------------+
| - _name        |
| - _price       |
| - _stock       |
+----------------+
| + Name         |
| + Price        |
| + Stock        |
| + ReduceStock(quantity): bool |
| + Restock(quantity): void     |
+----------------+

```

```pgsql

// OrderItem
+----------------+
|   OrderItem    |
+----------------+
| - _product     |
| - _quantity    |
+----------------+
| + Product      |
| + Quantity     |
| + GetTotalPrice() : decimal |
+----------------+

```

```pgsql

// Order
+----------------+
|     Order      |
+----------------+
| - _items       |
| - _orderId     |
| - _status      |
| - _customer    |
+----------------+
| + OrderID      |
| + Status       |
| + AddItem(Product, int): void |
| + CalculateTotal() : decimal |
| + UpdateStatus(string): void |
| + ShowOrder(): void          |
| + GetPackingLabel() : string|
| + GetShippingLabel() : string|
+----------------+

```

```

Flowchart / Program Flow Description
How the Program Runs:
plaintext
Copy
Edit
Main()
 └──> Create Products
 └──> Create Addresses
 └──> Create Customers
 └──> Create Orders
        └──> Add Items
            └──> Reduce Stock
        └──> Show Order
            └──> List Items + Total
            └──> Show Packing Label
            └──> Show Shipping Label
        └──> Update Status

```

        
