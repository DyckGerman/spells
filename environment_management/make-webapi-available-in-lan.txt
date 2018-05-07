## Make visual studio debug web-server available in local network
1. start debug session once
2. in VS project under `.vs` directory edit `applicationhost.config`. find your website section and add `<binding>` nodes
```
 <sites>
            <sites>
            <site name="WebSite1" id="1" serverAutoStart="true">
                <application path="/">
                    <virtualDirectory path="/" physicalPath="%IIS_SITES_HOME%\WebSite1" />
                </application>
                <bindings>
                    <binding protocol="http" bindingInformation=":8080:localhost" />
                </bindings>
            </site>
            <site name="IdentityManagement.API" id="2">
                <application path="/" applicationPool="Clr4IntegratedAppPool">
                    <virtualDirectory path="/" physicalPath="C:\projects\git\sp\system-app\IdentityManagement\IdentityManagement.API" />
                </application>
                <bindings>
			<binding protocol="http" bindingInformation="*:49787:localhost" />
			<binding protocol="http" bindingInformation="*:49787:192.168.56.1" />

                </bindings>
            </site>
            <siteDefaults>
                <logFile logFormat="W3C" directory="%IIS_USER_HOME%\Logs" />
                <traceFailedRequestsLogging directory="%IIS_USER_HOME%\TraceLogFiles" enabled="true" maxLogFileSizeKB="1024" />
            </siteDefaults>
            <applicationDefaults applicationPool="Clr4IntegratedAppPool" />
            <virtualDirectoryDefaults allowSubDirConfig="true" />
        </sites>
```
3. if the project is not available yet run the following command
```
netsh http add urlacl url=http://vaidesg:8080/ user=everyone
```




