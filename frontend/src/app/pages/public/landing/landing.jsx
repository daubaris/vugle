import React from 'react';
import { Pane, Strong } from 'evergreen-ui';

import Notifications from 'app/components/notifications/notifications';
import SuggestionsBubble from "../../../components/chat/suggestions-bubble/suggestions-bubble";
import SuggestionBar from "../../../components/chat/suggestion-bar/suggestion-bar";

class LandingPage extends React.Component {
	constructor(props) {
		super(props);

		this.state = {
			suggestions: [{
				id: 1,
				title: 'test'
			},{
				id: 2,
				title: 'test'
			},{
				id: 3,
				title: 'test'
			},{
				id: 4,
				title: 'test'
			}]
		};

		this.onClick = this.onClick.bind(this);
	}

	onClick(id) {
		alert(id);
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
				<SuggestionBar onClick={this.onClick} suggestions={ this.state.suggestions }/>
            </React.Fragment>
		);
	}
}

export default LandingPage;
