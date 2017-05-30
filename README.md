# couchbase_demo
A simple webapi (RESTful service) written in C#/.NET Core 2.0 using couchbase. It was written on a Red Hat Enterprise Linux machine, but Linux *is not* required. However, you will need a Couchbase instance running, and this particular demo uses a Couchbase demo database running in a local (i.e. localhost:8091) Linux container.  

## How to use this demo (details of each step are further in this document):  
1. Clone or download this repo.
1. Set up a Couchbase demo database and use the travel-demo database.
1. Build the .NET solution.
1. Use a tool such as Postman to execute HTTP POST and GET operations against this RESTful service.
1. Add to and/or improve the service as an exercise.

### Clone or download this repo
Either use 'git clone' or download the file from this page. It does not matter what you name the directory into which you place it, but couchbase_demo seems like the best idea.  

### Set up a Couchbase demo database and use the 'travel-demo' database.
The easiest way to do this is to use a Linux container. At the command line, the following commands will get a Couchbase demo instance up and running in seconds:  
`docker pull couchbase/server`  
`docker run -d --name db -p 8091-8094:8091-8094 -p 11210:11210 couchbase`  

Once the database is up and running, point your browser to localhost:8091 and follow the simple steps to get it set up.

**NOTE** If you are running your Linux instance in a VM and you are attempting to access the Couchbase browser-based setup from the host machine (example, you are running RHEL in a VM on a Windows machine), you will need to use the IP address of the VM instead of 'localhost'. For the Red Hat Container Development Kit, for example, that address is 10.1.2.2.

### Build the .NET Solution  
Once you are in your directory ('couchbase_demo' if you followed my suggestion, above), use the following commands at the command line:

`dotnet restore`  
`ASPNETCORE_URLS=http://*:5000`  
`dotnet run`

### Use a tool such as Postman to execute HTTP POST and GET operations against this RESTful service.  
Here's an example JSON document:
`{"Id":"131", "Type":"airline", "Name":"Braniff", "Iata":"BR", "Icao":"DFW", "Callsign":"BRANIFF", "Country":"United States"}`  

### Add to and/or improve this service as an exercise.
1. Each operation creates a database connection ("cluster"). That code needs to be refactored.  
1. The Update (PUT) and Delete (DELETE) operations have not been written.  
1. Right now, the GET returns the first two items. Making that number configurable and adding paging would be needed if this was going to be used in production.  
1. No exception handling is in place.  
1. Linq2Couchbase is available and would simplify things.  

--- END ---
