import React from 'react';
import { Pane, Strong } from 'evergreen-ui';

import Notifications from 'app/components/notifications/notifications';

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
		    <React.Fragment>
                <Notifications />
                <Pane
                    {...cardStyle}
                    elevation={ 1 }
                >
                    <Strong size={ 600 }>vugle</Strong>
                </Pane>
            </React.Fragment>
		);
	}
}

export default LandingPage;
