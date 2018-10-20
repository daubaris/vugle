import React from 'react';

import Notifications from 'app/components/notifications/notifications';
import Chat from 'app/components/chat/chat';
import Topbar from "./topbar/topbar";
import ChatInput from "../../../components/chat/chat-input/chat-input";

class LandingPage extends React.Component {
	render() {
		return (
		    <React.Fragment>
                <Topbar/>
                <Notifications />
                <Chat />
				<ChatInput/>
            </React.Fragment>
		);
	}
}

export default LandingPage;
