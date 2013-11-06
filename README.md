# Data Access Framework #

**Data Access Framework** provides an easy configuration parameters to create a database context for entity framework.


# Requirements #

* .NET Framework 4.5 or higher
* [Entity Framework 6.0](http://www.nuget.org/packages/EntityFramework) or higher


# Configurations #

In order to use **Data Access Framework** within your application, you should add the followings into your `app.config` or `web.config`.


## `configSections` ##

Add the following `<section>` element into the `<configSections>` element.

    <configSections>
        <section name="connectionSettings"
                 type="DataAccessFramework.Configuration.ConnectionSettings, DataAccessFramework.Configuration"
                 requirePermission="false" />
    </configSections>


## `connectionSettings` ##

Add the following `<connectionSettings>` element under the `<configuration>` element &ndash; the `root` element.

    <connectionSettings>
        <connectionDetails>
            <clear />
            <add key="ApplicationDataContext"
                 use="true"
                 type="EntityFramework"
                 dataContext="ApplicationDataContext"
                 dataSource="(LocalDB)\v11.0"
                 initialCatalog="ApplicationDatabase"
                 persistSecurityInfo="true"
                 integratedSecurity="true"
                 multipleActiveResultSets="true"
                 connectionTimeout="30"
                 provider="System.Data.SqlClient" />
        </connectionDetails>
    </connectionSettings>


# License #

**Data Access Framework** is released under [MIT License](http://opensource.org/licenses/MIT).

> The MIT License (MIT)
> 
> Copyright (c) 2013 [aliencube.org](http://aliencube.org)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
> furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
