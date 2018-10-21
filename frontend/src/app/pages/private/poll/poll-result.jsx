import React from 'react';
import Chart from "app/components/chart/chart";

class PollResult extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div>
        <div>
          <b>{this.props.data.title}</b>
        </div>
        <div>
          <Chart data={this.props.data.options} />
        </div>
        <div>
          {this.props.data.description}
        </div>
        <div>
          {this.props.data.date}
        </div>
      </div>
    );
  }
}

export default PollResult;