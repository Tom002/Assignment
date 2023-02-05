Welcome to the Régens backend developer interview assignment!

Your task is to implement a basic web API that serves historical weather data of cities. The assignment is divided into several steps of different complexity mostly building on the previous implemented step. You are expected to implement as many of these steps as you can.

We have prepared a starter project for you that you can build upon. This project already contains the database model and pre-creates the database on the first launch that you may use to implement the API. It also contains a preconfigured swagger UI that you can use to test your implementation. You are required to follow the exact API shape but you may implement the API in any way you see fit.
You will need the .NET SDK 7 or later (Visual Studio 2022 17.4 or later) to use the starter project.

You need to submit your assignment in the form of a GitHub repository. Be sure to exclude all assets from the source that are not required to build the project (e.g. database files, build outputs etc.)!

========== Level 1 ========== 

Implement the basic API that conforms to the following specifications
1. The API endpoint should be "GET /cities/{name}/weather" where {name} is the name of the city. For now the response should list all stored weather entries for the city.
2. The response should return with a json document that list all stored weather entries for the city in descending date order. The response should be in the following format:
[{ date: "2022-10-30", temperature: 14 }, { date: "2022-10-29", temperature: 15 }]
3. You should use asynchronous code. Don't block the request thread.
4. In case the city is not found in the database the response should be 404 Not Found
5. In case the city is found in the database but there are no weather entries the response should be an empty array.

========== Level 2 ==========

Right now the weather request returns all data for the chosen city which is unacceptable for a large database. Implement filtering and paging as per the following requirements:
1. Add the following query parameters: "page", "pageSize". For a query like /cities/Budapest/weather?page=2&pageSize=5 you should return entries 6-10.
2. Add the following query parameters: "from", "to". For a query like /cities/Budapest/weather?from=2022-10-01&to=2022-10-05 you should return entries between 1-5 oct 2022 (inclusive).
3. All parameters should be optional. If the request does not specify a parameter it should be defaulted as follows:
	- page: 1
	- pageSize: 5
	- from: if "to" is specified then "to" -30 days, otherwise today -30 days
	- to: if "from" is specified then "from" +30 days, otherwise today
4. In case the city is not found in the database the response should still be 404 Not Found
5. In case the city is found in the database but no records can be found matching the specified filters (be it date or page) the response should be an empty array.

========== Level 3 ==========

The current API shape still allows a caller to query the entire database. Implement the following validation rules:
1. "page" should be greater than equal to 1
2. "pageSize" should be between 1 and 10 (inclusive)
3. "from" and "to" should not refer to a span of more than 30 days

If any validation rule is violated then return 400 Bad Request.

========== Level 4 ==========

The API is currently hard to use if the caller does not know the cities available in the database. Create an endpoint that allows searching the cities in the database:
1. The API endpoint should be "GET /cities?name={prefix}" where {prefix} is optional
2. You should only return cities whose name starts with {prefix} (if it's specified)
3. You should return results in alphabetical order
4. You should return at most 5 results

========== Level 5 ==========

Add a summary column to the weather data:
1. Add a column named "Summary" to the weather records in the database.
2. For existing data, where temperature is less than 10 set summary to 'cool and calm', otherwise set summary to 'nice and warm'.
3. Return the value of this field in the weather results. Return the value exactly as in the database, do not use an expression to calculate the value on-demand.
4. Create a migration that automatically updates the existing database with the new column and values on application start.
