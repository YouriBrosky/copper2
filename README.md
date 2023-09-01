**Project Overview**

This project consists of two separate components that communicate with each other via HTTP requests, while adhering to the principles of loose coupling and high cohesion. Each component implements a common interface, allowing them to interact without direct knowledge of each other's implementation.

Key Features
Interface-Driven Design: Both components implement the IManagerOne interface, which defines the methods available for communication.
HTTP Proxy: A special HttpProxy class is used to intercept calls to the interface methods. This proxy handles the actual HTTP requests, allowing the components to remain decoupled.
Serialization: Newtonsoft.Json is used for serializing and deserializing data when making the HTTP requests.
Dependency Injection: .NET Core's built-in dependency injection is used to inject either the real implementation or the HTTP proxy into the classes, based on the configuration.
