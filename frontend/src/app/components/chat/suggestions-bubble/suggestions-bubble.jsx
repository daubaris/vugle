import React from 'react';
import { Pane } from 'evergreen-ui';
import { Col, Row } from 'reactstrap';

class SuggestionsBubble extends React.Component {
	constructor(props) {
		super(props);

		this.onClick = this.onClick.bind(this);
	}

	onClick() {
		this.props.onClick(this.props.id);
	}

	render() {
		const cardStyles = {
			borderRadius: 3,
			padding: 10,
			margin: 5
		};

		return (
			<Pane
				{...cardStyles}
				elevation={ 1 }
				onClick={ this.onClick }>
				{ this.props.title }
			</Pane>
		);
	}
}

export default SuggestionsBubble;
