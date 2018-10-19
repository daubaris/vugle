import React from 'react';
import SuggestionsBubble from '../suggestions-bubble/suggestions-bubble';
import styles from './suggestions-bar.scss';

class SuggestionBar extends React.Component {
	render() {
		const {
			suggestions,
			onClick
		} = this.props;

		return (
			<div className={ styles['suggestion-bar'] }>
				{ suggestions.map(suggestion => (
					<SuggestionsBubble
						key={ suggestion.id }
					    id={ suggestion.id }
					    title={ suggestion.title }
						onClick={ onClick }
					/>
				))}
			</div>
		);
	}
}

export default SuggestionBar;
