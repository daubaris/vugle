import React from 'react';
import { Pane } from 'evergreen-ui';

class SuggestionsBubble extends React.Component {
	constructor(props) {
		super(props);

		this.onClick = this.onClick.bind(this);
	}

	onClick() {
		this.props.onClick(this.props.suggestion);
	}

	render() {
		const cardStyles = {
			borderRadius: 3,
			padding: 10,
			margin: 5
		};

		const {
			suggestion,
		} = this.props;

		return (
			<Pane
				{...cardStyles}
				elevation={ 1 }
				onClick={ this.onClick }>
				{ suggestion.title }
			</Pane>
		);
	}
}

export default SuggestionsBubble;
