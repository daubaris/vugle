import React from 'react';
import { Pane } from 'evergreen-ui';
import styles from './suggestions-bubble.scss';

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
				className={ styles['suggestions-bubble'] }
					{...cardStyles}
					onClick={ this.onClick }>
					{ suggestion.title }
				</Pane>
		);
	}
}

export default SuggestionsBubble;
