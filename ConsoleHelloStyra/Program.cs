using System.Text;
using System.Text.Json;
using ModSystem = ConsoleHelloStyra.Models.System;

Console.WriteLine("Hello, World!");

// Create a system

var apiToken = "l2O0czsf9L05GXZWicEW-BzpiT1yPR0VzybiYJaatd2aBAHqjaAGhac";

var system = new ModSystem { Name = "NewJose", Type = "custom"};
var jsonString = JsonSerializer.Serialize(system).ToLower();

var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiToken);
httpClient.BaseAddress = new Uri("https://insight.svc.styra.com/v1/");

var response = await httpClient.PostAsync("systems", new StringContent(jsonString, Encoding.UTF8, "application/json"));

response.EnsureSuccessStatusCode();

Console.WriteLine($" {system.Name} created successfully!");