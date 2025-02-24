  # Kavim API Controllers

This repository contains the API controllers for the Kavim project. These controllers handle requests related to streets, buses, and stations.  The API uses ASP.NET Core and leverages AutoMapper for object mapping.

## Table of Contents

- [Project Overview](#project-overview)
- [Controllers](#controllers)
  - [StreetController](#streetcontroller)
  - [BusController](#buscontroller)
  - [StationController](#stationcontroller)
- [Dependencies](#dependencies)
- [Usage](#usage)
- [Contributing](#contributing)

## Project Overview

The Kavim project aims to provide a platform for managing and accessing information about transportation, including streets, buses, and stations.  This repository focuses specifically on the API controllers that expose endpoints for interacting with this data.

## Controllers

### StreetController

The `StreetController` handles requests related to streets.

- **`GET /api/Street`**: Retrieves a list of streets, optionally filtered by name and city.  Uses query parameters `name` and `city`. Returns an `ActionResult` containing a collection of `StreetDto` objects. Example: `/api/Street?name=Main&city=Jerusalem`
- **`GET /api/Street/{id}`**: Retrieves a specific street by its ID. Returns an `ActionResult` containing a `StreetDto` object or `NotFound` if the street is not found.
- **`POST /api/Street`**: Creates a new street. Accepts a `NameAndCity` object in the request body. Returns an `IActionResult` indicating success.
- **`PUT /update/{id}`**: Updates an existing street. Accepts a `NameAndCity` object in the request body and the street's ID in the URL. Returns an `IActionResult` indicating success or `NotFound` if the street is not found.
- **`PUT /addStation/{id}`**: Adds a station to a street. Accepts a `NameAndCity` object (representing the station) in the request body and the street's ID in the URL. Returns an `IActionResult` indicating success or `NotFound` if the street is not found.
- **`DELETE /api/Street/{id}`**: Deletes a street by its ID. Returns an `IActionResult` indicating success or `NotFound` if the street is not found.

### BusController

The `BusController` handles requests related to buses.

- **`GET /api/Bus/{id}`**: Retrieves a specific bus by its ID. Returns an `ActionResult` containing a `BusDto` object or `NotFound` if the bus is not found.
- **`GET /api/Bus`**: Retrieves a list of buses, optionally filtered by name, destination, source, and company. Uses query parameters `name`, `destination`, `source`, and `company`. Returns an `ActionResult` containing a collection of `BusDto` objects.
- **`POST /api/Bus`**: Creates a new bus. Accepts a `Busfrombody` object in the request body. Returns an `IActionResult` indicating success.
- **`PUT /update{id}`**: Updates an existing bus. Accepts a `Busfrombody` object in the request body and the bus's ID in the URL. Returns an `IActionResult` indicating success or `NotFound` if the bus is not found.
- **`PUT /addStation{id}`**: Adds a station to a bus's route. Accepts a `StationPut` object in the request body and the bus's ID in the URL. Returns an `IActionResult` indicating success or `NotFound` if the bus is not found.
- **`DELETE /api/Bus/{id}`**: Deletes a bus by its ID. Returns an `IActionResult` indicating success.

### StationController

The `StationController` handles requests related to stations.

- **`GET /api/Station`**: Retrieves a list of all stations. Returns an `ActionResult` containing a collection of `StationDto` objects.
- **`GET /api/Station/{id}`**: Retrieves a specific station by its ID. Returns an `ActionResult` containing a `StationDto` object or `NotFound` if the station is not found.
- **`POST /api/Station`**: Creates a new station. Accepts a `NameAndCity` object in the request body. Returns an `IActionResult` indicating success.
- **`PUT /api/Station/{id}`**: Updates an existing station. Accepts a `NameAndCity` object in the request body and the station's ID in the URL. Returns an `IActionResult` indicating success or `NotFound` if the station is not found.
- **`DELETE /api/Station/{id}`**: Deletes a station by its ID. Returns an `IActionResult` indicating success or `NotFound` if the station is not found.

## Dependencies

- AutoMapper
- Kavim.Core (includes classes, repositories, and services)
- Microsoft.AspNetCore.Mvc

## Usage
## Getting Started 
### Prerequisites 
- .NET 6.0 or higher 
 ### Installation 
 1. Clone the repository:bash git clone https://github.com/debifogel/Kavim.git 
 2. Navigate to the project directory:bash cd Kavim 
 3. Restore dependencies:bash dotnet restore 
 4. Run the application:bash dotnet run 
 ## Testing the API You can test the API endpoints using tools like Postman or curl. ## License This project is licensed under the MIT License.
To use these controllers, you need to have a running instance of the Kavim API.  Refer to the main Kavim repository for instructions on setting up and running the project.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

