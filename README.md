# JWDLiberaCodeTest

To run the tests, simply load in visual studio, build, open the test manager and run all.
To hit the api endpoints, set the api project as startup and run the application.
	The endpoints for postman are:
		GET http://localhost:54199/streetdistance/closest?X=1&Y=3
		POST http://localhost:54199/streetdistance/street   with a raw json input example of
			{ 
			   "name": "Street2",
			   "start": [0,2],
			   "end": [2,2]
			}
