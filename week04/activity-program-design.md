<h2>Program 1: YouTube Videos – Design Overview</h2>
<h5>What does the program do?</h5>

<strong>This program models a video platform where each video has a title, length, author, and a collection of comments.</strong>

The program:
<br>Creates several Video objects.
<br>Adds several Comment objects to each video.
<br>Stores all videos in a list.
<br>Iterates over the list of videos to display their details and associated comments on the console.
<br>Essentially, it simulates a basic data structure for videos with comments, similar to YouTube videos and their comments.

<h5>What are candidates for classes?</h5>
Video: Represents a video with its details and comments.
<br>Comment: Represents a comment with a commenter name and text.

<br>Program: The entry point, responsible for running the application.
<br>Optional candidates (not currently in the code but could be considered in a larger design):

<br>User: Could represent the author or commenter if expanded.
<br>CommentCollection: To handle comments separately if the comments logic grows.
<br>VideoCollection: To handle a list of videos if we want to extend functionality.

<h5>What are the responsibilities of each class?</h5>
Video class
<h5>Attributes:</h5>
Title: The video's title.
<br>Length: Duration in seconds.
<br>Author: The creator or uploader.
<br>_comments: A private list of Comment objects.

<h5>Responsibilities (Methods):</h5>
Store and provide video details.
<br>Add comments to the video.
<br>Return the number of comments.
<br>Provide read-only access to comments.

<h5>Comment class</h5>
Attributes:

<br>CommenterName: The name of the person commenting.
<br>Text: The content of the comment.

<br>Responsibilities (Methods):
<br>Store commenter's name and comment text.

<h5>Program class</h5>
Responsibilities (Methods):
<br>Create videos.
<br>Create comments and add to videos.
<br>Display videos and comments.


After the Meeting: Individual Design Steps
Additional Classes (Optional)
User: to represent authors and commenters as real objects.

VideoCollection: to manage multiple videos with additional behaviors.

CommentManager: to handle comment filtering or sorting.
Behaviors (Methods)

For Video:
<br> ``` AddComment() ```
<br> ``` GetNumberOfComments() ```
<br> ``` GetComments() ```

<br>For Comment:
<br>Constructor to initialize comment.

For Program:
<br> ``` Main() ``` to run the program.
<br>Attributes (Member Variables)

For Video:
<br> ``` Title ```
<br> ``` Length ```
<br> ``` Author ```
<br> ``` _comments ```

For Comment:
<br> ``` CommenterName ```
<br> ``` Text ```


<h5>Class Diagram (Simple UML representation) </h5>

```pgsql

+---------------------+
|       Video         |
+---------------------+
| - Title: string      |
| - Length: int        |
| - Author: string     |
| - _comments: List<Comment> |
+---------------------+
| + AddComment(c: Comment)  |
| + GetNumberOfComments(): int |
| + GetComments(): IReadOnlyList<Comment> |
+---------------------+

          1
          |
          * contains
          |
+---------------------+
|      Comment        |
+---------------------+
| - CommenterName: string |
| - Text: string          |
+---------------------+
| + Comment(name, text)   |
+---------------------+


```

<br>Flowchart or Method Interaction Description
<br>The Program creates a list of videos.

<br>For each video:
<br>The program creates the video object.
<br>Adds comments using ``` AddComment() ```.
<br>Adds the video to the videos list.
<br>Then, the program loops through each video, printing video details and all comments by calling ``` GetComments() ``` and ``` GetNumberOfComments() ```.


<br>
<hr>
<br>

<h2>Program 2: Online Ordering – Design Overview</h2>

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

        
