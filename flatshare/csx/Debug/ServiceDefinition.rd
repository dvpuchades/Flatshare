<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="flatshare" generation="1" functional="0" release="0" Id="3dddc0b9-2218-427e-9c57-f27b9d156186" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="flatshareGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="WebRole:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/flatshare/flatshareGroup/LB:WebRole:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="WebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/flatshare/flatshareGroup/MapWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WebRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/flatshare/flatshareGroup/MapWebRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:WebRole:Endpoint1">
          <toPorts>
            <inPortMoniker name="/flatshare/flatshareGroup/WebRole/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/flatshare/flatshareGroup/WebRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWebRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/flatshare/flatshareGroup/WebRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="WebRole" generation="1" functional="0" release="0" software="C:\Users\dvpuc\source\repos\flatshare\flatshare\csx\Debug\roles\WebRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WebRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WebRole&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/flatshare/flatshareGroup/WebRoleInstances" />
            <sCSPolicyUpdateDomainMoniker name="/flatshare/flatshareGroup/WebRoleUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/flatshare/flatshareGroup/WebRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="WebRoleUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="WebRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="WebRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="9a2b175c-8462-480e-a0a4-8e5fdd945cc9" ref="Microsoft.RedDog.Contract\ServiceContract\flatshareContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="660bd09e-47a8-4c05-9519-5a6990a28269" ref="Microsoft.RedDog.Contract\Interface\WebRole:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/flatshare/flatshareGroup/WebRole:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>