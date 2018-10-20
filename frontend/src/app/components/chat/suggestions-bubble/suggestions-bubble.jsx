import React from 'react';
import { Pane } from 'evergreen-ui';
import classnames from 'classnames';

import styles from './suggestions-bubble.scss';

class SuggestionsBubble extends React.Component {
	constructor(props) {
		super(props);

		this.onClick = this.onClick.bind(this);
	}

	onClick() {
		const {
			onClick,
            suggestion,
			disabled,
		} = this.props;

		if (!disabled) {
			onClick(suggestion);
		}
	}

	render() {
		const cardStyles = {
			borderRadius: 3,
			padding: 10,
			margin: 5,
			whiteSpace: 'nowrap',
		};

		const {
			suggestion,
			disabled,
		} = this.props;

		const classname = classnames(
			styles['suggestions-bubble'],
            disabled && styles['disabled'],
		);

		return (
			<Pane
				{...cardStyles}
				elevation={ 1 }
				onClick={ this.onClick }
				className={ classname }
			>
				{ suggestion.title }
			</Pane>
		);
	}
}

export default SuggestionsBubble;
