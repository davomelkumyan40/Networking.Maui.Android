# Networking.Maui.Android

[![NuGet Badge](https://img.shields.io/nuget/v/Networking.Maui.Android.svg)](https://www.nuget.org/packages/Networking.Maui.Android)
[![License](https://img.shields.io/badge/license-Apache%202.0-blue.svg)](LICENSE)

**Networking.Maui.Android** is a .NET MAUI library that provides useful Netwokring tools to use for Android in your application. This library is build in base of another Java library (**AndroidNetworkTools** [link to repo](https://github.com/stealthcopter/AndroidNetworkTools)) in order to simplify Networking in .NET MAUI. feel free to fork and add your features to the project by creating pull request on it.

## Table of Contents
- [Features](#features)
- [Getting Started](#getting-started)
- [Installation](#installation)
- [Usage and examples](#usage-and-examples)
- [Contribution](#contribution)
- [License](#license)

## Features
- Easy access to Networking of Andoird
- Simple API for fast usage.
- Java native code behind
- **Main Functionality**
- Port Scanning
- Subnet Device Finder (discovers devices on local network)
- Ping
- Wake-On-Lan

## Getting Started
- Install Nuget package [![NuGet Badge](https://img.shields.io/nuget/v/Networking.Maui.Android.svg)](https://www.nuget.org/packages/Networking.Maui.Android)

OR

- You can install the library via NuGet:

## Installation

**.NET CLI**
```bash
dotnet add package Networking.Maui.Android
```

**Package Manager Console**
```bash
NuGet\Install-Package Networking.Maui.Android
```

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0.0 or later)
- [.NET MAUI](https://dotnet.microsoft.com/en-us/apps/maui)
- Permission in MAUI app manifest xml file
```xml
 <uses-permission android:name="android.permission.INTERNET" />
```

## Usage and examples
  - **Device Search**
  ```csharp
  var foundDevices = await SubnetScanner.Instance.FindDevicesAsync();
  var foundDevices = await SubnetScanner.Instance.FindDeviceByIpAsync(ip);
  ```

- **Ping**
```csharp
//sync
var result = await Pinger.Instance.Ping(ipText.Text, pingCount: 2);
//async
var result = await Pinger.Instance.PingAsync(ipText.Text, pingCount: 2);
  ```
- **Port Scan**
```csharp
//sync
 var foundPorts = await PortScanner.Instance.Scan(ip, [10, 20, 80, 90], 1000, Enums.TransportType.Tcp);
//async
 var foundPorts = await PortScanner.Instance.ScanAsync(ip, [10, 20, 80, 90], 1000, Enums.TransportType.Tcp);
  ```

* **Utility methods**
```csharp
//methods inside NetworkUtils class
NetworkUtils.GetMacAddressFromIp(ip);
NetworkUtils.GetIpAddressFromMac(mac);
NetworkUtils.GetMacAddressBytes(mac);
NetworkUtils.IsValidMacAddress(mac);
NetworkUtils.IsIPv6Address(ip);
NetworkUtils.IsIPv4Address(ip)
NetworkUtils.IsIPv6HexCompressedAddress(ip);
NetworkUtils.IsIpAddressLocalNetwork(ip);
NetworkUtils.IsIPv6StdAddress(ip);
NetworkUtils.GetLocalIpv4Address();
NetworkUtils.IsIpAddressLocalhost(ip);
```

For more additional examples and info you can install Demo Application in repository of project.


# Contribution

1) Fork it
2) Create your feature branch
```bash
git checkout -b new-feature
```
3) Commit your changes
```bash
git commit -am 'feature to approve'
```
4) Push to the branch
```bash
git push origin my-new-feature
```
5) Create new Pull Request

## License
[![License](https://img.shields.io/badge/license-Apache%202.0-blue.svg)](LICENSE)
