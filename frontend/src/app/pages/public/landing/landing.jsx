import React from 'react';

import Notifications from 'app/components/notifications/notifications';
import Chat from 'app/components/chat/chat';
import Topbar from "./topbar/topbar";
import ResultBubble from "../../../components/chat/result-bubble/result-bubble";

class LandingPage extends React.Component {
	render() {
		return (
		    <React.Fragment>
                <Topbar/>
				<ResultBubble/>
                <Notifications />
                <Chat />
            </React.Fragment>
		);
	}
}

export default LandingPage;
