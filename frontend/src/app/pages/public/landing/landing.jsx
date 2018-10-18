import React from 'react';
import {Pane, Card, Strong} from 'evergreen-ui';

class LandingPage extends React.Component {
	render() {
		const cardStyle = {
			margin: 0,
			height: 70,
			display: 'flex',
			justifyContent: 'center',
			alignItems: 'center'
		};

		return (
			<Pane
				{...cardStyle}
				elevation={ 1 }
			>
				<Strong size={ 600 }>vugle</Strong>
			</Pane>
		);
	}
}

export default LandingPage;
