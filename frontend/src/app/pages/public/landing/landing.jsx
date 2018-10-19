import React from 'react';
import { Pane, Strong } from 'evergreen-ui';

import Notifications from 'app/components/notifications/notifications';
import Chat from 'app/components/chat/chat';

class LandingPage extends React.Component {
	constructor(props) {
		super(props);
	}

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
                <Chat />
            </React.Fragment>
		);
	}
}

export default LandingPage;
