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

<h3> Program 2: Online Ordering – Design Overview </h3>
What Does the Program Do?
This program simulates an online ordering system by allowing:
Creation of products with price and stock
Customers to place orders with specific products and quantities
Stock checks and reductions when ordering
Total price calculation for the order
Status updates on the order

It showcases encapsulation by protecting and managing data within classes using private setters and controlled methods (e.g., ReduceStock(), CalculateTotal()).

Candidate Classes & Responsibilities
Class	Purpose / Responsibility
Product	Represents an item that can be ordered. Manages stock, price, and product name.
OrderItem	Represents a product + quantity combo in an order. Calculates total price for the item.
Order	Stores a collection of OrderItems, handles adding items, order status, and calculating total.
Program	Entry point for the application. Simulates product creation, order creation, and interactions.

Class Details and Product Class
Attributes:
Name: string — Product name
Price: decimal — Unit price
Stock: int — Quantity in stock

Methods:
ReduceStock(quantity) — Deducts from stock if enough is available
Restock(quantity) — Adds more to stock

OrderItem Class
Attributes:
Product: Product — The product being ordered
Quantity: int — Number of units ordered

Methods:
GetTotalPrice() — Returns product price × quantity

Order Class
Attributes:

OrderID: string — Unique identifier for the order
Status: string — Tracks current order state (e.g., "Pending", "Shipped")
items: List<OrderItem> — Collection of order items

Methods:

AddItem(product, quantity) — Adds an item to the order if stock is available
CalculateTotal() — Sums total cost of all order items
UpdateStatus(newStatus) — Updates order status
ShowOrder() — Displays order summary


```pgsql 

+------------------------+
|        Product         |
+------------------------+
| - Name: string         |
| - Price: decimal       |
| - Stock: int           |
+------------------------+
| + ReduceStock(q): bool |
| + Restock(q): void     |
+------------------------+

+--------------------------+
|       OrderItem          |
+--------------------------+
| - Product: Product       |
| - Quantity: int          |
+--------------------------+
| + GetTotalPrice(): dec.  |
+--------------------------+

+------------------------------+
|           Order              |
+------------------------------+
| - OrderID: string            |
| - Status: string             |
| - items: List<OrderItem>     |
+------------------------------+
| + AddItem(p, q): void        |
| + CalculateTotal(): decimal  |
| + UpdateStatus(s): void      |
| + ShowOrder(): void          |
+------------------------------+

+----------------------+
|      Program         |
+----------------------+
| + Main(args): void   |
+----------------------+

```

<h5> Program Flow Overview </h5>
Create Product instances with names, prices, and stock.
Create an Order using an OrderID.
Add items to the order using AddItem() (which checks stock).
Display order details using ShowOrder() (with calculated totals).
Update order status using UpdateStatus().

