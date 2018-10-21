import React from 'react';

class Chart extends React.Component {
  constructor(props) {
    super(props);
  }

  hasVotes() {
    var totalVotes = 0;
    this.props.data.forEach(
      function(option){
          totalVotes += +option.value;
      }
    )
    return totalVotes > 0;
  }

  parseOptions() {
    return this.props.data.map(option => (
      {
        "value": option.value,
        "label": option.title,
      }
    ))
  }

  render() {
    var PieChart = require("react-chartjs").Pie;

    var chartOptions = {
      //Boolean - Whether we should show a stroke on each segment
      segmentShowStroke: true,

      //String - The colour of each segment stroke
      segmentStrokeColor: "#fff",

      //Number - The width of each segment stroke
      segmentStrokeWidth: 2,

      //Number - The percentage of the chart that we cut out of the middle
      percentageInnerCutout: 50, // This is 0 for Pie charts

      //Number - Amount of animation steps
      animationSteps: 100,

      //String - Animation easing effect
      animationEasing: "easeOutBounce",

      //Boolean - Whether we animate the rotation of the Doughnut
      animateRotate: true,

      //Boolean - Whether we animate scaling the Doughnut from the centre
      animateScale: false,
      // {% raw %}
      // //String - A legend template
      // legendTemplate : "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<segments.length; i++){%><li><span style=\"background-color:<%=segments[i].fillColor%>\"><%if(segments[i].label){%><%=segments[i].label%><%}%></span></li><%}%></ul>"
      // {% endraw %}
    };

    return (
      <React.Fragment>
        { this.hasVotes() && <PieChart data={this.parseOptions()} options={chartOptions} /> }
        { !this.hasVotes() && <div><i>Balsų nėra</i></div> }
      </React.Fragment>
    );
  }
}

export default Chart;