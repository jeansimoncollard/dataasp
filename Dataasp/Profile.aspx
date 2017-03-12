<%@ Page Title="Your Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Dataasp.About" %>
    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <!-- Features Section -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header"><%: Title %></h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 full-height">
                <div class="row">
                    <h3 style="margin-top: 60px;"><strong>Environmental Impact</strong></h3>
                    <p>Your way of life has measurable costs on the environment. On this chart is displayed how much CO2 was released on the latest registered trips.</p>
                    <ul>
                        <li><strong>Here are the most well known consequences:</strong>
                        </li>
                        <em><li>Sea level rising</li>
                        <li>More frequent extrem weather</li>
                        <li>Ecosystem changes</li>
                        <li>Spread of diseases</li>
                        <li>Increased global warmth</li></em>
                    </ul>
                    <p>A tree can absorb as much as 0.45kg of CO2 per year!</p>
                </div>
            </div>
            <div class="col-md-6 full-height">
                <div class="row">
                    <canvas id="myLineChart" width="100" height="100"></canvas>
                </div>
            </div>
        </div>
        <!-- /.row -->
        <!-- Service Tabs -->
        <div class="row">
            <div class="col-lg-12">
                <ul id="myTab" class="nav nav-tabs nav-justified">
                    <li class="active"><a href="#MyStats" data-toggle="tab"><i class="fa fa-car"></i>My Stats</a>
                    </li>
                    <li class=""><a href="#Community" data-toggle="tab"><i class="fa fa-users"></i>Community</a>
                    </li>
                    <li class=""><a href="#Resources" data-toggle="tab"><i class="fa fa-tree"></i>Resources</a>
                    </li>
                </ul>
                <div id="myTabContent" class="tab-content">
                    <div class="tab-pane fade active in" id="MyStats">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="panel panel-default text-center">
                                    <div class="panel-heading">
                                        <canvas id="myChart" width="100" height="100"></canvas>
                                    </div>
                                    <div id="drivingAlternatives"class="panel-body">
                                        <h4>Driving Alternatives</h4>
                                        <p></p>
                                        <a href="#" class="btn btn-primary">Learn More</a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="panel panel-default text-center">
                                    <div class="panel-heading">
                                        <canvas id="DistanceChart" width="100" height="100"></canvas>
                                    </div>
                                    <div class="panel-body">
                                        <h4>Driving Alternatives</h4>
                                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
                                        <a href="#" class="btn btn-primary">Learn More</a>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="panel panel-default text-center">
                                    <div class="panel-heading">
                                        <canvas id="CostChart" width="100" height="100"></canvas>
                                    </div>
                                    <div class="panel-body">
                                        <h4>Money you've saved</h4>
                                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
                                        <a href="#" class="btn btn-primary">Learn More</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                   <div class="tab-pane fade" id="Community">
                    <div class="row">
                        <div class="col-md-6">
                            <ul>
                                <li class="element-top-10 element-bottom-10">
                                    Your Friend Sebastian saved $30 this month with Bixi
                                </li>
                                <li class="element-top-10 element-bottom-10">
                                    On Average you produce 1.25 times as much CO2 as your friends
                                </li>
                                <li class="element-top-10 element-bottom-10">
                                    You just passed John for CO2 emission for this month! watch out!
                                </li>
                                <li class="element-top-10 element-bottom-10"> 
                                    Susan suggest a bike ride to work tomorrow!(Y/N)
                                </li>
                            </ul>
                            </div>
                           <div class="col-md-6">
                            <canvas id="myRadarChart" width="100" height="100"></canvas>
                               </div>
                       </div></div>
                    <div class="tab-pane fade" id="Resources">
                        <h4>Coming Soon!</h4>
                        <p><Strong>Ecobecois</Strong> is excited to announce the upcoming release of rideshare capabilities, Ridesharing creates a meaningful way to give back to your community and the environment and meet some like minded people along the way!</p>
                        <p>We're not quite ready to let loose yet though, so in the mean time take advantage of our local <a href ="https://montreal.bixi.com/en">Bixi</a>, <a href ="https://www.rtcquebec.ca/">Bus Routes</a>, or just enjoy a day in one of our lovely <a href ="https://www.sepaq.com/pq/index.dot?language_id=1">parks</a></p>
                    </div>
                </div>
            </div>
        </div>
        <!-- Service List -->
        <!-- The circle icons use Font Awesome's stacked icon classes. For more information, visit http://fontawesome.io/examples/ -->
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header">Interesting Facts</h2>
            </div>
            <div class="col-md-4">
                <div class="media">
                    <div class="pull-left">
                        <span class="fa-stack fa-2x">
                        <i class="fa fa-circle fa-stack-2x text-primary"></i>
                        <i class="fa fa-car fa-stack-1x fa-inverse"></i>
                    </span>
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">Your car and Green House Gases</h4>
                        <p>"While GHGs are emitted in the extraction phase of the crude oil production process, most of the life cycle emissions of fuel come from a vehicle’s tailpipe. Final combustion of gasoline emerging from your tailpipe accounts for approximately 70%-80% of well-to-wheel life-cycle emissions."
                            <br />
                            <a href="http://www.nrcan.gc.ca/energy/oil-sands/18091">Gov. Canada</a>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="media">
                    <div class="pull-left">
                        <span class="fa-stack fa-2x">
                        <i class="fa fa-circle fa-stack-2x text-primary"></i>
                        <i class="fa fa-leaf fa-stack-1x fa-inverse"></i>
                    </span>
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">Green Alternatives to Diesel</h4>
                        <p>"Biodiesel is a diesel fuel substitute used in diesel engines made from renewable materials such as:
                            <strong>Plant oils:</strong> canola, camelina, soy, flax, jatropha, mahua, pongamia pinnata, mustard, coconut, palm, hemp and sunflower;
                            <strong>Waste cooking oil:</strong>yellow or tap grease;
                            <strong>Other oils:</strong> tall, fish, and algae;
                            <strong>Animal fats:</strong>beef or sheep tallow, pork lard, or poultry fat; and Potentially from cellulosic feedstock consisting of agriculture and forest biomass."
                            <br />
                            <a href="http://www.nrcan.gc.ca/energy/alternative-fuels/fuel-facts/biodiesel/3509">Learn more here</a>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="media">
                    <div class="pull-left">
                        <span class="fa-stack fa-2x">
                        <i class="fa fa-circle fa-stack-2x text-primary"></i>
                        <i class="fa fa-globe fa-stack-1x fa-inverse"></i>
                    </span>
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">How Much CO2 is too Much?</h4>
                        <p>"Burning 1 L of gasoline produces approximately 2.3 kg of CO2. This means that the average Canadian vehicle, which burns 2,000 L of gasoline every year, releases about 4,600 kg of CO2 into the atmosphere."
                            <br /><a href="https://www.nrcan.gc.ca/energy/efficiency/transportation/cars-light-trucks/buying/16770">Learn more here</a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        </div>
        <!-- /.row -->
        <hr>
    <script>
        var ctx = document.getElementById("myChart").getContext('2d');
        var myChart = new Chart(ctx, {
            type: 'doughnut',
            options: {
                title: {
                    display: true,
                    text: 'Travel type percentage'
                },
                animation: {
                    animateScale: true
                }
            },
            data: {
                labels: ["Walking", "Biking", "Public Transit", "Driving"],
                datasets: [{
                    backgroundColor: [
                        "#2ecc71",
                        "#3498db",
                        "#95a5a6",
                        "#9b59b6",
                    ],
                    data:  <%= Chart1Data %>,
                }]
             }
             });
             var tranType = <%= Chart1Data %>;
             var preferedType;

             if (tranType[0] >= tranType[1] && tranType[0] >= tranType[2] && tranType[0] >= tranType[4]) {
                 //If walking is greatest
                 preferedType = 0;
             } else if (tranType[1] >= tranType[2] && tranType[1] >= tranType[3] && tranType[1] >= tranType[0]) {
                 //If Biking is greatest
                 preferedType = 1;
             } else if (tranType[2] >= tranType[3] && tranType[2] >= tranType[0] && tranType[2] >= tranType[1]) {
                 //If Public Transit is greatest
                 preferedType = 2;
             } else {
                 //Else Driving is greatest
                 preferedType = 3;
             }
             switch (preferedType) {
                 case 0:

                     $('#drivingAlternatives').append('<h4>Driving Alternatives</h4><p>You\'re preferred mode of transport is AAAAA.</p><a href="#" class="btn btn-primary">Learn More</a>')
                 case 1:

                     $('#drivingAlternatives').append('<h4>Driving Alternatives</h4><p>You\'re preferred mode of transport is AAAAA.</p>')
                 case 2:

                     $('#drivingAlternatives').append('<h4>Driving Alternatives</h4><p>You\'re preferred mode of transport is AAAAA.</p>')
                 case 3:

                     $('#drivingAlternatives').append('<h4>Driving Alternatives</h4><p>You\'re preferred mode of transport is AAAAA.</p>')
             }
        </script>
        <script>
            var ctx4 = document.getElementById("CostChart");
            var CostChart = new Chart(ctx4, {
                type: 'bar',
                data: {
                    labels: ["Walking", "Biking", "Public Transit", "Car"],
                    datasets: [{
                        label: "Total travel expenditure " + "$" +<%= totalCostData %>,
                        data: <%= costData %>,
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)'
                        ],
                        borderColor: [
                            'rgba(255,99,132,1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)',
                            'rgba(255, 159, 64, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    title: {
                        display: true,
                        text: 'Travel costs'
                    },
                    scales: {
                        yAxes: [{
                            scaleTitle: "$",
                            ticks: {
                                beginAtZero: true,
                            }
                        }]
                    }
                }
            });
        </script>
        <script>
            var ctx3 = document.getElementById("DistanceChart");
            var DistanceChart = new Chart(ctx3, {
                type: 'bar',
                data: {
                    labels: ["Walking", "Biking", "Public Transit", "Car"],
                    datasets: [{
                        label: 'Kilometers',
                        data: <%= DistanceChartData %>,
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)'
                        ],
                        borderColor: [
                            'rgba(255,99,132,1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)',
                            'rgba(255, 159, 64, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    title: {
                        display: true,
                        text: 'Distance by Type'
                    },
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true,
                            }
                        }]
                    }
                }
            });
        </script>
        <script>
            var ctx2 = document.getElementById("myLineChart");
            var myLineChart = new Chart(ctx2, {
                type: 'line',
                data: {
                    labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                    datasets: [{
                        label: 'total CO2 generated : ' + <%=totalCO2Str%>,
                    data: <%= ChartOnCO2Data %>,
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(255, 206, 86, 0.2)',
                        'rgba(75, 192, 192, 0.2)',
                        'rgba(153, 102, 255, 0.2)',
                        'rgba(255, 159, 64, 0.2)'
                    ],
                    borderColor: [
                        'rgba(255,99,132,1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 159, 64, 1)'
                    ],
                    borderWidth: 1
                    }]
                },
                options: {
                    title: {
                        display: true,
                        text: 'CO2 Emissions'
                    },
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true,
                            }
                        }]
                    }
                }
            });
        </script>
        <script>
            var ctx5 = document.getElementById("myRadarChart");
            var myRadarChart = new Chart(ctx5, {
                type: 'radar',
                data: {
                    labels: ["C02 emission", "Travel Cost", "walks", "Bikes", "Public Transit", "Total Distance", "Calories"],
                    datasets: [
                        {
                            label: "Me",
                            backgroundColor: "rgba(179,181,198,0.2)",
                            borderColor: "rgba(179,181,198,1)",
                            pointBackgroundColor: "rgba(179,181,198,1)",
                            pointBorderColor: "#fff",
                            pointHoverBackgroundColor: "#fff",
                            pointHoverBorderColor: "rgba(179,181,198,1)",
                            data: [80, 65, 45, 25, 46, 65, 45]
                        },
                        {
                            label: "Steve",
                            backgroundColor: "rgba(255,99,132,0.2)",
                            borderColor: "rgba(255,99,132,1)",
                            pointBackgroundColor: "rgba(255,99,132,1)",
                            pointBorderColor: "#fff",
                            pointHoverBackgroundColor: "#fff",
                            pointHoverBorderColor: "rgba(255,99,132,1)",
                            data: [60, 65, 65, 70, 56, 60, 35]
                        },
                        {
                            label: "Laura",
                            backgroundColor: "rgba(99,255,132,0.2)",
                            borderColor: "rgba(99,255,132,1)",
                            pointBackgroundColor: "rgba(99,255,132,1)",
                            pointBorderColor: "#fff",
                            pointHoverBackgroundColor: "#fff",
                            pointHoverBorderColor: "rgba(99,255,132,1)",
                            data: [45, 65, 80, 35, 56, 55, 70]
                        }
                    ]
                },
                options: {
                    scale: {
                        ticks: {
                            beginAtZero: true
                        }
                    },
                    title: {
                        display: true,
                        text: 'Monthly Improvement'
                    },
                }
            });
    </script>
    </asp:Content>