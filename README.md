# HockeyApi
An API for returning hockey players.
## How to build
- The application is a .NET Core 3.1 http REST API application.
- Use Visual Studio 2019 or VS Code with .NET Core 3.1 SDK to build
- Tests made with XUnit, can be run with in Visual Studio IDE or with XUnit CLI

The application data layer and tests use csv files added to project resources. If you want to change them, rebuild the project for changes to be added to resource strings.
## How to use
Run the application in IDE, the application runs at localhost port 5001. Two apis are served.
The api methods can be also accessed using swagger at https://localhost:5001/index.html. (The swagger is lacking documentation due to not time to learn usage.)
### /api/players
Players api return players loaded in the application sorted by team name (ascending), player position (order C, RW, LW, LD, RW, G), and number (ascending)
### /api/teams
Teams api returns players in a team (team name as get parameter) ordered by ascending player number.

There are three default teams in team api at /api/team that can be queried:
- Lukonmäen Luja
- Muotialan Mainio
- Hervannan Häkki



## Notes on technical solutions
- The data layer of the application is a poor man´s one using a static data provider class initiated at application Startup code.
