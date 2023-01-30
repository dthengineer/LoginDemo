https://youtu.be/qwlKXxtND5Q

Requirement said nothing about creating new users or password prompts.  
So the data is read only with little in terms of checks for validity
But a simple Valid() function on each data class will take care of that.

Sorry no Mock test.  Wasn't listed in requirement.  If you want Mock Unit test, write me.

Database Creation:
1. Right click on LoginDatabase project.  "menu:Publish"
2. Load Profile from Publish locations
3. If you change the database name, please alter LoginDemo's App.Config file for the new connection string
4. Publish.  It will be a localDB and fully populated.

Running Program:
1.  Make sure LoginDemo app.config is pointed to the right database.
2.  Run LoginDemo
3.  The Login class contains the meat and potatoes of the code.  I outline the spec points in comments

Every program has layers that can be presented in Interface layers that allow substitution (Solid principles)
IPresentation <- How I present information to the user (The console in this case.  But it's such such a simple program it doesn't need an interface)

IBusinessLayer <- What are the rules of interaction and data processing (Login does the busines.  But it's such a simple program it doesn't need an interface)
If you needed to create this the primary methods would be the promptForName, AnswerFlow, and StoreFlow methods

IDataLayer <- The data structures used (DataLayer project)

IStorageLayer <- The transport or the method of how that data gets back and forth (StorageLayer Project)

Why did I use a question # and user # as primary keys?
Strings are mutable.  A user may with to update their name.  We may need to add support for foreign languages in the future.
So the text will change.  But the user ID and question ID are permanent.  Making text fields as primary keys is generally a no-no.


