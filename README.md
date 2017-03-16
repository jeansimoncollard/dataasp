

 ![18-Ecobecois – screenshot 1](https://challengepost-s3-challengepost.netdna-ssl.com/photos/production/software_photos/000/487/556/datas/gallery.jpg)


## Inspiration

In the last couple of years there has been a growing trend in environmental concern. Our application is designed with the average citizen in mind who is concerned about the environment, but lacks the resources to fully understand their impact on a global level, with the goal to reduce that impact.

## What it does

Ecobecois is designed to allow users to track and interact with data from their commutes. As well as gather a substantial amount of pertinent data. It achieves these goals through a variety of functionalities mainly our itinerary page. Ecobecois uses self-developed algorithms to allow the user to plan their transportation needs through an extremely unique and personalizable medium. Users can add routes to their profile and save their travel history to calculate a variety of statistics including: Carbon footprint, distance traveled, costs saved by using alternative modes of transportations, and others. This application also allows the user to interact with their friends and community`s data, with the aim of motivating users to improve personal habits and encourage community growth around sustainable ideals.

## How we built it

Ecobecois was built as a web application using ASP.NET webform framework. It uses C# as a backend language with a MS Sql database. Javascript, CSS and Jquery were used as frontend languages. We used Google Maps API for distance calculation and itinerary display.The modern-business template was used from startbootstrap open source Github repository. Chartjs was chosen to display our variety of statistics in dynamic charts. Ecobecois is currently being hosted on an Azure Windows 2016 server. The IDE we used was Visual Studio 2015/2017, Sublime and Nuget was used for package management.

External ressources: [https://github.com/sethwebster/GoogleMaps.LocationServices](https://github.com/sethwebster/GoogleMaps.LocationServices) [https://github.com/chartjs](https://github.com/chartjs) [https://github.com/BlackrockDigital/startbootstrap-modern-business](https://github.com/BlackrockDigital/startbootstrap-modern-business)

## Datasets

[https://www.donneesquebec.ca/recherche/fr/dataset/lieux-habites-du-quebec](https://www.donneesquebec.ca/recherche/fr/dataset/lieux-habites-du-quebec) - Scenic Route [https://www.donneesquebec.ca/recherche/fr/dataset/chantiers-transports-quebec](https://www.donneesquebec.ca/recherche/fr/dataset/chantiers-transports-quebec) - Avoid Construction [https://www.donneesquebec.ca/recherche/fr/dataset/radars-photo-transports-quebec](https://www.donneesquebec.ca/recherche/fr/dataset/radars-photo-transports-quebec) - Avoid Speed Trap

## Challenges we ran into

The challenges we have run into are not yet finished as HackQC 2017 is still ongoing.

We encountered an unexpected problem with the scoring system to generate waypoints for the pathfinding algorithm. We had to validate that these waypoints were not being generated in lakes or in unreachable places. We overcame this problem by making sure Google Maps could find a path to link each waypoint before they were considered by the scoring algorithm.

As we were 5 working in a relatively small project, we were often modifying the same files, creating too many merge conflicts. Fortunately, Visual Studio, our IDE, provides us with a user-friendly interface to merge those conflicts.

## Accomplishments that we're proud of

We are really happy to have successfully let everybody contribute to the project regardless of their prior coding experience. Two of our 5 members were first-year students and they really did impressive contribution to the project.

We are really proud of our pathfinding algorithm. Even though it could be optimized, it is a huge algorithm to implement accurately considering the datasets we are using, and we think we have done a pretty good job for the time we had.

## What we learned

As we were all new to ASP.NET, which is our main framework, we learned it really well. Each of us learned many other technologies as we had a wide range of technologies we were using, this includes Bootstrap, C#, Javascript and many others. We learned how to work in team to deploy a prototype that works in a really short amount of time using Github.

## What's next for Ecobecois

In the future, we would like to add to our application a GPS localizer so that the statistics can be calculated without the user having to enter them. We couldn't do this in a weekend as we chose to develop a web app for its quick deployment advantage and its accessibility to all platforms. A web app doesn't have access to GPS localization, but we could embed in native apps that have this access.

## Github

[https://github.com/noblefr/dataasp](https://github.com/noblefr/dataasp)




## Try it out

*   [<span>hackqc.azurewebsites.net</span>](http://hackqc.azurewebsites.net "http://hackqc.azurewebsites.net")

