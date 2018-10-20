import React from 'react';

import Notifications from 'app/components/notifications/notifications';
import Chat from 'app/components/chat/chat';
import Topbar from "./topbar/topbar";

class LandingPage extends React.Component {
	render() {
		return (
		    <React.Fragment>
                <Topbar/>
                <Notifications />
                <Chat />
            </React.Fragment>
		);
	}
}

export default LandingPage;
