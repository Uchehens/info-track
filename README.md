README

InfoTrack SEO Tracker is a simple appliction that uses simple algorithm to identify the Search engine ranking of infotrack.co.uk  domain
It works by identifying all external link or site as returned by engine on search page and then using it to rank (in the order of result)and compute the trending of the various sites. 

In order to ensure the search result set do not return unnecessary site there exist an ExemptionList field in the [appsettings.json]( https://gitlab.com/hexdata/infotrack/-/blob/master/InfoTrack.Web/appsettings.json) to excude this sites from the result set

I have unboarded multiple search engines namely google.co.uk,bing.com,google.com

INSTALL

1. Clone the repository and Build or Rebuild All the Solution

2. Create the Database

  i.  Ensure you have a master access to the database instance

  ii. Ensure  you do not have any database with name InfoTrack else backup in a save location and delete.

  iii.Execute the [InfoTrackDb.sql](https://gitlab.com/hexdata/infotrack/-/blob/master/InfoTrack.Infrastructure/Pesistance/DatabaseScript/InfoTrackDb.sql) in the InfoTrack.Infrastructure Project.
    
3. Updating Database ConnectionString (Assuming that InfoTrack database was created successfully above)

Locate the [appsettings.json]( https://gitlab.com/hexdata/infotrack/-/blob/master/InfoTrack.Web/appsettings.json)  File of InfoTrack.Web Project
 Modify the **InfoTrackConnection** Value

  i.	If you have a Window Authentication right add the following value _server=[ServerName];database=InfoTrack;trusted_connection=true_;

  ii.	If you have using SQL Server Authentication add the following value _data source=[ServerName];Database= InfoTrack; uid=[Username]; pwd=[Password];_
   
   Remember you have to replace [ServerName], [Username] and [Password] with your database server instance values.


PROJECT EXECUTION

Using visual studio the current Startup Project is InfoTrack.Web in case this has changed kindly update appropriately by right-clicking the project and selecting Set as Startup Project. 

The hit F5 or Ctrl + F5 to start the project

Once the site opens enter the search engine of choice the domain name eg www.google.co.uk,www.bing.com,www.google.com  and the search keyword then press search

KNOWN ISSUES

During the cause of test google.com and google.co.uk will start to block request after a number of search request returning _The remote server returned an error: (429) Too Many Requests_ this will reset after 24 hours
