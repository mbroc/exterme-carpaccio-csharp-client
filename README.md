# IUT Lyon 1 evaluation bootstrap

This solution contains an empty bootstrap project using Nancy (a light weight web server lib).

## First check all is working

- you have access to the main server in a browser (URL given on whiteboard)
- you need to setup autorisation to run a web server : netsh http add urlacl url=http://+:8080/ user="Tout le monde"
- you can then build solution and run it, it should open a web server in console with message "Your application is running..."
- try to open your server URL (http://localhost:8080/), it should display a message like "It works..."
- register your server on main server, with your real first/last name, your should see some logs in your server console
- if not check your firewall settings (disable it or add a rule to allow request on port 8080)

## During workshop, be careful of

- being disconnected make you loose money, /!\ to server restart (you can run your server from command line also, instead of Debug mode from VS)
- commit frequently, with good comments
- a strategy : try to earn money as soon as possible (use small steps, one after the other...)

## What will be evaluated

- the money your earned (the result)
- but also how you have done it:
    - unit tests (granularity, independance, fast, comprehensive = easy to understand/expressive)
	- git commits history (granularity, comments that explains why you changed something more than which files have been changed!)
	- code design (single responsability), but too much not "overdesigned"
	- code quality (rules provided by R# must be fixed, but the one on Bill.total which must remain camel case for JSON serialization)
