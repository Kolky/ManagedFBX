ManagedFBX is a .NET wrapper for Autodesk's FBX SDK, written in C++/CLI.

# Building from source

* Install the [FBX SDK](http://usa.autodesk.com/adsk/servlet/pc/item?id=24735038&siteID=123112)
* Ensure that the ManagedFbx project is pointing at the correct library and headers for the SDK
* Build the solution and verify it's working correctly by running the sample project provided

# Building from source using Unreal Engine 4

* Download the [FBX SDK](http://usa.autodesk.com/adsk/servlet/pc/item?id=24735038&siteID=123112)
* Extract the dll & lib files to, in the appropriate folders;
  > Engine\Source\ThirdParty\FBX\2016.1.1\lib\
* Ensure that build configuration is set to either X64 or X86
* Ensure that the ManagedFbx project is pointing at the correct library and headers for the SDK
* Build the solution and verify it's working correctly by running the sample project provided