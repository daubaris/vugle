import React from 'react';
import Chart from "app/components/chart/chart";
import moment from 'moment';

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
          Aprašymas: {this.props.data.description}
        </div>
        <div>
          Data: {moment(this.props.data.date).format('YYYY-MM-DD HH:mm')}
        </div>
      </div>
    );
  }
}

export default PollResult;