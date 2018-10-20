import React from 'react';

class Chart extends React.Component {
    constructor(props) {
        super(props);

    }

    render() {
      var PieChart = require("react-chartjs").Pie;
  
      var chartData = [
        {
          value: 300,
          color: "#00072D",
          highlight: "#2E3453",
        },
        {
          value: 50,
          color: "#FFFFFF",
          highlight: "#FFFFFF",
        },
        {
          value: 100,
          color: "#1098F7",
          highlight: "#3BAAF8",
        },
        {
          value: 100,
          color: "#EBBAB9",
          highlight: "#EEC6C5",
        },
        {
          value: 100,
          color: "#D7263D",
          highlight: "#DE4D60",
        },
      ];
  
      var chartOptions = {
        //Boolean - Whether we should show a stroke on each segment
        segmentShowStroke : true,
      
        //String - The colour of each segment stroke
        segmentStrokeColor : "#fff",
      
        //Number - The width of each segment stroke
        segmentStrokeWidth : 2,
      
        //Number - The percentage of the chart that we cut out of the middle
        percentageInnerCutout : 50, // This is 0 for Pie charts
      
        //Number - Amount of animation steps
        animationSteps : 100,
      
        //String - Animation easing effect
        animationEasing : "easeOutBounce",
      
        //Boolean - Whether we animate the rotation of the Doughnut
        animateRotate : true,
      
        //Boolean - Whether we animate scaling the Doughnut from the centre
        animateScale : false,
        // {% raw %}
        // //String - A legend template
        // legendTemplate : "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<segments.length; i++){%><li><span style=\"background-color:<%=segments[i].fillColor%>\"><%if(segments[i].label){%><%=segments[i].label%><%}%></span></li><%}%></ul>"
        // {% endraw %}
      };
      
      return (
          <React.Fragment>
          <PieChart data={this.item.data} options={chartOptions}/>
              </React.Fragment>
      );
    }
}

export default Chart;
