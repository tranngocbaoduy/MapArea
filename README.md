# MapArea
Manage Area By App  
------------------------------------
This is app mange, collect, update area'information based on my idea. It's work in available area which we added. You can add, update and manage it.
------------------------------------
How to set up program
Step 1: After open folder, you create a new database named MyMap (must be named MyMap). Then, you restore file availible MyMap.bak to database MyMap.
Step 2: Open the project. In your right, you’ll see a folder Model. Double click to open it, then you delete file Model1.edmx. 
Step 3: After that, you double click in MyMap and add new item, choose Data and add ADO.NET Entity Data Model named default is Model1. After you click add, the project show a table, click Next and click New Connection. Fill your server name and choose your database MyMap. Click OK. It’ll show you a name such as MyMapEntities. You should copy this name, click Next, choose table and click Finish. 
Step 4: Wait a minutes, the project show a few table with a relationship. In a corner of window, you’ll see a simple like SAVE ALL, click it and wait for a moment. After finish, it’ll generate a named file is Model1.edmx. 
Step 5: Double click it, click Model1.tt. You’ll see file VERTEX.cs and VERTEX_VERTEX.cs. In the folder project which I give you, open it and get 2 file Vertex.cs and Vertex_vertex.cs copy all into 2 file just generate. 
Step 6: In the right, you also see the folder DBConnection. Open it, and open file DataProvider.cs. At row 29 and 33, you’ll delete name MyMapEntities current and fill the name which you copied a moment ago. And Save All
Step 7: If you are sure you have followed the steps above, let start project. 

Link tutorial set up: https://youtu.be/UmkRJCArRcc
