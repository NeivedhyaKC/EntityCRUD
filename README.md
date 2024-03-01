A Simple Rest API with endpoints serving Entity Data from a mocked database. 
Done as part of an assignment for an internship.

The EntityController class is responsible for serving rest endpoints. At the moment it handles business logic as well.
The mocked datasbase is a static list created in the DataContext.cs file. It is referenced throughout the project as DataContext.entities.
The schema model specified in the assignment is described in the Entity.cs file.

The post, put and delete methods are self-explanatory.
The get method takes in multiple optional parameters. The search parameter is checked against a few fields for a match. The entities 
are also filtered by gender, birth date falling between the range of startDate and endDate, and list of countries.
After that the list is sorted and a paged list is returned as output.
