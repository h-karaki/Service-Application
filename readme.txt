
===================================================================================

I.Purpose:
----------

This program tries to find out which addresses are within a given area. The program requires
an input.txt file. The first line of the file consists of the coordinates of the bounding area.

****


****
Note: Negatives are supported.

Required format of bounding area:
(X.XXXX, Y.YYYY), (X.XXXX, Y.YYYY)

Any subsequent lines are each a "testing address" input. 
eg. 30840 Northwestern Highway, Farmington Hills, MI

The resulting file looks like:

(X.XXXX, Y.YYYY), (X.XXXX, Y.YYYY)
30840 Northwestern Highway, Farmington Hills, MI

Any number of addresses may be given after the bounding area. Formatting is limited to what 
the Google Maps API can accept as input. Results may vary, however, you may try to search the 
address on Google Maps to determine if it is considered an acceptable input. If Google Maps determines
the location is searchable by zooming into the actual location of said input, it is considered 
acceptable input. 

The result will be output to Terminal. A Log.txt file is created to reveal actual address to coordinate
translation and time of program initialization. 

II.Prerequisites:
-----------------

A working internet connection
-OS: Windows with .NET 4.5.2 framework installed 

III.Dependencies:
----------------

Autofac requires:
-.NET 4.5 (a .NETStandard library >= 1.6 could be used instead)
System.ComponentModel (>= 4.0.1)

RestSharp:
None

IV.Installation: 
--------------

No installation is required. As of now, dependent .dll files should be in the same directory
as the executable. 

