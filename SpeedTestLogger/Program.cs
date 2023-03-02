﻿// See https://aka.ms/new-console-template for more information
using SpeedTestLogger;
using System.Globalization;
using SpeedTestLogger.Models;

Console.WriteLine("Hello SpeedTestLogger!");

var config = new LoggerConfiguration();
var runner = new SpeedTestRunner(config.LoggerLocation);
var testData = runner.RunSpeedTest();
var results = new TestResult(
    SessionId: Guid.NewGuid(),
    User: config.UserId,
    Device: config.LoggerId,
    Timestamp: DateTimeOffset.Now.ToUnixTimeMilliseconds(),
    Data: testData);
runner.RunSpeedTest();


/* 
var client = new SpeedTestClient();
var settings = client.GetSettings();

Console.WriteLine("Finding best test servers");

var location = new RegionInfo("nb-NO");
var tenLocalServers = settings.Servers
    .Where(s => s.Country.Equals(location.EnglishName))
    .Take(10);

var serversOrdersByLatency = tenLocalServers
    .Select(s =>
    {
        s.Latency = client.TestServerLatency(s);
        return s;
    })
    .OrderBy(s => s.Latency);

var server = serversOrdersByLatency.First();

Console.WriteLine("Testing download speed");
var downloadSpeed = client.TestDownloadSpeed(server, settings.Download.ThreadsPerUrl);
Console.WriteLine("Download speed was: {0} Mbps", Math.Round(downloadSpeed / 1024, 2));

Console.WriteLine("Testing upload speed");
var uploadSpeed = client.TestUploadSpeed(server, settings.Upload.ThreadsPerUrl);
Console.WriteLine("Upload speed was: {0} Mbps", Math.Round(uploadSpeed / 1024, 2));

 */