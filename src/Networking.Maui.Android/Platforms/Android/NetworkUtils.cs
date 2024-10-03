
using Com.Stealthcopter.Networktools;
using Java.IO;
using InetAddress = Java.Net.InetAddress;
using Runtime = Java.Lang.Runtime;

namespace Networking.Maui.Android;

public static class NetworkUtils
{
    public static string GetMacAddressFromIp(string ipAddress) => ARPInfo.GetMACFromIPAddress(ipAddress);
    public static string GetIpAddressFromMac(string mac) => ARPInfo.GetIPAddressFromMAC(mac);
    public static byte[] GetMacAddressBytes(string mac) => MACTools.GetMacBytes(mac);
    public static bool IsValidMacAddress(string mac) => MACTools.IsValidMACAddress(mac);
    public static bool IsIPv6Address(string ipAddress) => IPTools.IsIPv6Address(ipAddress);
    public static bool IsIPv4Address(string ipAddress) => IPTools.IsIPv4Address(ipAddress);
    public static bool IsIPv6HexCompressedAddress(string ipAddress) => IPTools.IsIPv6HexCompressedAddress(ipAddress);
    public static bool IsIpAddressLocalNetwork(InetAddress ipAddress) => IPTools.IsIpAddressLocalNetwork(ipAddress);
    public static bool IsIPv6StdAddress(string ipAddress) => IPTools.IsIPv6StdAddress(ipAddress);
    public static InetAddress GetLocalIpv4Address() => IPTools.LocalIPv4Address;
    public static bool IsIpAddressLocalhost(InetAddress ipAddress) => IPTools.IsIpAddressLocalhost(ipAddress);
}
