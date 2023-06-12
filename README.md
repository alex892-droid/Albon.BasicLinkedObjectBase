# TxtDatabase

TxtDatabase is a local text file database project in C# using Newtonsoft.Json package, very easy to use for fast project implementation.
It saves/deletes/updates/search for any instance of classes you want in files (tables equivalent) automatically and dynamically without any big configuration required.

HOW TO USE:
1) Add the TxtDatabase project to your solution.
2) Choose or create a new attribute that the database will use to know the unique key property of your instances of classes and put that attribute on the property in the class you want to be saveable.

Change the attribute in DatabaseService file:
``` C#
public class DatabaseService : DatabaseService<YourAttribute>, IDatabaseService
```

3) Use IDatabaseService exposed methods like Add, Delete, Update, Query in your code.
4) Enjoy !
