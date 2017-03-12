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
                    <p>Your way of life has measurable costs on the environment. On this chart is displayed how much CO2 was released on the latest registered trips.</p>
                    <ul>
                        <li><strong>Here are the most well known consequences:</strong>
                        </li>
                        <li>Sea level rising</li>
                        <li>More frequent extrem weather</li>
                        <li>Ecosystem changes</li>
                        <li>Spread of diseases</li>
                        <li>Increased global warmth</li>
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
                        <h4>Service Two</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quae repudiandae fugiat illo cupiditate excepturi esse officiis consectetur, laudantium qui voluptatem. Ad necessitatibus velit, accusantium expedita debitis impedit rerum totam id. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Natus quibusdam recusandae illum, nesciunt, architecto, saepe facere, voluptas eum incidunt dolores magni itaque autem neque velit in. At quia quaerat asperiores.</p>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quae repudiandae fugiat illo cupiditate excepturi esse officiis consectetur, laudantium qui voluptatem. Ad necessitatibus velit, accusantium expedita debitis impedit rerum totam id. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Natus quibusdam recusandae illum, nesciunt, architecto, saepe facere, voluptas eum incidunt dolores magni itaque autem neque velit in. At quia quaerat asperiores.</p>
                    </div>
                    <div class="tab-pane fade" id="Resources">
                        <h4>Service Three</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quae repudiandae fugiat illo cupiditate excepturi esse officiis consectetur, laudantium qui voluptatem. Ad necessitatibus velit, accusantium expedita debitis impedit rerum totam id. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Natus quibusdam recusandae illum, nesciunt, architecto, saepe facere, voluptas eum incidunt dolores magni itaque autem neque velit in. At quia quaerat asperiores.</p>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quae repudiandae fugiat illo cupiditate excepturi esse officiis consectetur, laudantium qui voluptatem. Ad necessitatibus velit, accusantium expedita debitis impedit rerum totam id. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Natus quibusdam recusandae illum, nesciunt, architecto, saepe facere, voluptas eum incidunt dolores magni itaque autem neque velit in. At quia quaerat asperiores.</p>
                    </div>
                </div>
            </div>
        </div>
        <!-- Service List -->
        <!-- The circle icons use Font Awesome's stacked icon classes. For more information, visit http://fontawesome.io/examples/ -->
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header">Service List</h2>
            </div>
            <div class="col-md-4">
                <div class="media">
                    <div class="pull-left">
                        <span class="fa-stack fa-2x">
                        <i class="fa fa-circle fa-stack-2x text-primary"></i>
                        <i class="fa fa-tree fa-stack-1x fa-inverse"></i>
                    </span>
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">Service One</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Illo itaque ipsum sit harum.</p>
                    </div>
                </div>
                <div class="media">
                    <div class="pull-left">
                        <span class="fa-stack fa-2x">
                        <i class="fa fa-circle fa-stack-2x text-primary"></i>
                        <i class="fa fa-car fa-stack-1x fa-inverse"></i>
                    </span>
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">Service Two</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Illo itaque ipsum sit harum.</p>
                    </div>
                </div>
                <div class="media">
                    <div class="pull-left">
                        <span class="fa-stack fa-2x">
                        <i class="fa fa-circle fa-stack-2x text-primary"></i>
                        <i class="fa fa-support fa-stack-1x fa-inverse"></i>
                    </span>
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">Service Three</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Illo itaque ipsum sit harum.</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="media">
                    <div class="pull-left">
                        <span class="fa-stack fa-2x">
                        <i class="fa fa-circle fa-stack-2x text-primary"></i>
                        <i class="fa fa-database fa-stack-1x fa-inverse"></i>
                    </span>
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">Service Four</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Illo itaque ipsum sit harum.</p>
                    </div>
                </div>
                <div class="media">
                    <div class="pull-left">
                        <span class="fa-stack fa-2x">
                        <i class="fa fa-circle fa-stack-2x text-primary"></i>
                        <i class="fa fa-bomb fa-stack-1x fa-inverse"></i>
                    </span>
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">Service Five</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Illo itaque ipsum sit harum.</p>
                    </div>
                </div>
                <div class="media">
                    <div class="pull-left">
                        <span class="fa-stack fa-2x">
                        <i class="fa fa-circle fa-stack-2x text-primary"></i>
                        <i class="fa fa-bank fa-stack-1x fa-inverse"></i>
                    </span>
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">Service Six</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Illo itaque ipsum sit harum.</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="media">
                    <div class="pull-left">
                        <span class="fa-stack fa-2x">
                        <i class="fa fa-circle fa-stack-2x text-primary"></i>
                        <i class="fa fa-paper-plane fa-stack-1x fa-inverse"></i>
                    </span>
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">Service Seven</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Illo itaque ipsum sit harum.</p>
                    </div>
                </div>
                <div class="media">
                    <div class="pull-left">
                        <span class="fa-stack fa-2x">
                        <i class="fa fa-circle fa-stack-2x text-primary"></i>
                        <i class="fa fa-space-shuttle fa-stack-1x fa-inverse"></i>
                    </span>
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">Service Eight</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Illo itaque ipsum sit harum.</p>
                    </div>
                </div>
                <div class="media">
                    <div class="pull-left">
                        <span class="fa-stack fa-2x">
                        <i class="fa fa-circle fa-stack-2x text-primary"></i>
                        <i class="fa fa-recycle fa-stack-1x fa-inverse"></i>
                    </span>
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">Service Nine</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Illo itaque ipsum sit harum.</p>
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
                    labels: <%= Chart2Dates %>,
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
    </asp:Content>
