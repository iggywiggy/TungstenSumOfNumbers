Synopsis

Developer Tech Test, I've gone down the route of a WebAPI 2. The project is running on port 5000 so to access the api please use http://localhost:5000/api/{controllername}

Project Setup

The project has two controllers:

A calculate controller which has a AddTwoIntegers end point, which is a post method. The two integer parameters should be passed in as part of the query string for example:

http://localhost:5000/api/calculate?integerOne=1&integerTwo=1 This would return 2 as a string.
I've used IModelBinder to check the validility of the parameters being passed in from the query string.

A Logger controller which has a single GetLogFileContents end point, which is a get request. This will return the entire contents of the log file. The log file will log all completed requests.

http://localhost:5000/api/Logger
The delivery of the log contents could be delivered as a json object depending on the client usages.
Several log files could be setup - one for requests and another for error logging but at the moment both go into the one.

Time Spent On Project

Testing could be much better around the parameter validation and logging. If I had more time then I would have worked on a front end, my front end skills are not great but this is something I'm hoping to rectify. 

Comments

There are no comments within the project as I believe code should be self documenting. I've used ninject as a DI container and NUnit and Moq for unit testing frameworks.